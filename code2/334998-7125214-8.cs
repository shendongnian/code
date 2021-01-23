	public static class MappingExtensions
	{
		// this is one possibility for setting up object mappings
		#region Type Map Definition Section
			// * set up the MapInfo<TOther>() call in each object to map
			// * setup as follows to map two types to an actual map
			public static Tuple<Type, Type> MapFromTo<TFromType, TToType>()
			{
				return Tuple.Create<Type,Type>(typeof(TFromType), typeof(TToType));
			}
			static Dictionary<
				Tuple<Type, Type>,
				Tuple<Dictionary<string, string>, List<string>>
			>
			MappingDefinitions =
				new Dictionary <
					Tuple<Type,Type>,
					Tuple<Dictionary<string,string>,List<string>>
				> 
				{
					{ MapFromTo<MyClass,MyClass2>(), MyClass.MapInfo<MyClass2>() },
					{ MapFromTo<MyClass,MyClass3>(), MyClass.MapInfo<MyClass3>() },
				};
		#endregion
		// method using Reflection.GetPropertyInfo and mapping info to do copying
		// * for fields you will need to reflect using GetFieldInfo() instead
		// * for both you will need to reflect using GetMemberInfo() instead
		public static void CopyFrom<TFromType, TToType>(
				this TToType parThis,
				TFromType parObjectToCopy
			)
		{
			var Map = MappingDefinitions[MapFromTo<TFromType, TToType>()];
			Dictionary<string,string> MappedNames = Map.Item1;
			List<string> ExcludedNames = Map.Item2;
			Type FromType = typeof(TFromType);  Type ToType = typeof(TToType);
			
			// ------------------------------------------------------------------------
			// Step 1: Collect PIs for TToType and TFromType for Copying
			// ------------------------------------------------------------------------
			// Get PropertyInfos for TToType
			// the desired property types to reflect for ToType
			var ToBindings =
				BindingFlags.Public | BindingFlags.NonPublic  // property visibility 
				| BindingFlags.Instance                       // instance properties
				| BindingFlags.SetProperty;                   // sets for ToType
			// reflect an array of all properties for this type
			var ToPIs = ToType.GetProperties(ToBindings);
			// checks for mapped properties or exclusions not defined for the class
			#if DEBUG
				var MapErrors =
					from name in 
						MappedNames.Values
					where !ToPIs.Any(pi => pi.Name == name)
					select string.Format(
						"CopyFrom<{0},{1}>: mapped property '{2}' not defined for {1}",
						FromType.Name, ToType.Name, name
					);
			#endif
			// ------------------------------------------------------------------------
			// Get PropertyInfos for TFromType
			// the desired property types to reflect; if you want to use fields, too, 
			//   you can do GetMemberInfo instead of GetPropertyInfo below
			var FromBindings =
				BindingFlags.Public | BindingFlags.NonPublic  // property visibility 
				| BindingFlags.Instance                       // instance/static
				| BindingFlags.GetProperty;                   // gets for FromType
			// reflect all properties from the FromType
			var FromPIs = FromType.GetProperties(FromBindings);
			// checks for mapped properties or exclusions not defined for the class
			#if DEBUG
				MapErrors = MapErrors.Concat(
					from mn in MappedNames.Keys.Concat(
						ExcludedNames)
					where !FromPIs.Any(pi => pi.Name == mn)
					select string.Format(
						"CopyFrom<{0},{1}>: mapped property '{2}' not defined for {1}",
						FromType.Name, ToType.Name, mn
					)
				);
				// if there were any errors, aggregate and throw 
				if (MapErrors.Count() > 0)
					throw new Exception(
						MapErrors.Aggregate(
							"", (a,b)=>string.Format("{0}{1}{2}",a,Environment.NewLine,b)
					));
			#endif
			// exclude anything in the exclusions or not in the ToPIs
			FromPIs = FromPIs.Where(
				fromPI => 
					!ExcludedNames.Contains(fromPI.Name)
					&& ToPIs.Select(toPI => toPI.Name).Concat(MappedNames.Keys)
						.Contains(fromPI.Name)
			)
			.ToArray();
			// Step 1 Complete 
			// ------------------------------------------------------------------------
			// ------------------------------------------------------------------------
			// Step 2: Copy Property Values from Source to Destination 
			#if DEBUG
				Console.WriteLine("Copying " + FromType.Name + " to " + ToType.Name);
			#endif
			// we're using FromPIs to drive the loop because we've already elimiated 
			// all items that don't have a matching value in ToPIs
			foreach (PropertyInfo FromPI in FromPIs)
			{
				PropertyInfo ToPI;
				// if the 'from' property name exists in the mapping, use the mapped 
				//   name to find ToPI, otherwise use ToPI matching the 'from' name
				if (MappedNames.Keys.Contains(FromPI.Name))
					ToPI = ToPIs.First(pi => pi.Name == MappedNames[FromPI.Name]);
				else
					ToPI = ToPIs.First(pi => pi.Name == FromPI.Name);
				Type FromPropertyType = FromPI.PropertyType;
				Type ToPropertyType = ToPI.PropertyType;
				// retrieve the property value from the object we're copying from; keep
				// in mind if this copies by-reference for arrays and other ref types,
				// so you will need to deal with it if you want other behavior
				object PropertyValue = FromPI.GetValue(parObjectToCopy, null);
				// only need this if there are properties with incompatible types
				// * implement IConvertible for user-defined types to allow conversion
				// * you can try/catch if you want to ignore items which don't convert
				if (!ToPropertyType.IsAssignableFrom(FromPropertyType))
					PropertyValue = Convert.ChangeType(PropertyValue, ToPropertyType);
				// set the property value on the object we're copying to
				ToPI.SetValue(parThis, PropertyValue, null);
				#if DEBUG
					Console.WriteLine(
						"\t"
						+ "(" + ToPI.PropertyType.Name + ")" + ToPI.Name
						+ " := "
						+ "(" + FromPI.PropertyType.Name + ")" + FromPI.Name 
						+ " == " 
						+ ((ToPI.PropertyType.Name == "String") ? "'" : "")
						+ PropertyValue.ToString()
						+ ((ToPI.PropertyType.Name == "String") ? "'" : "")
					);
				#endif
			}
			// Step 2 Complete
			// ------------------------------------------------------------------------
		}
	}
