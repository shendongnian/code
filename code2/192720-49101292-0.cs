		public static T Transform<T>(this object myobj, string excludeFields = null)
		{
			// Compose a list of unwanted members
			if (string.IsNullOrWhiteSpace(excludeFields))
				excludeFields = string.Empty;
			excludeFields = !string.IsNullOrEmpty(excludeFields) ? excludeFields + "," : excludeFields;
			excludeFields += $"{nameof(DBTable.ID)},{nameof(DBTable.InstanceID)},{nameof(AuditableBase.CreatedBy)},{nameof(AuditableBase.CreatedByID)},{nameof(AuditableBase.CreatedOn)}";
			var objectType = myobj.GetType();
			var targetType = typeof(T);
			var targetInstance = Activator.CreateInstance(targetType, false);
			// Find common members by name
			var sourceMembers = from source in objectType.GetMembers().ToList()
									  where source.MemberType == MemberTypes.Property
									  select source;
			var targetMembers = from source in targetType.GetMembers().ToList()
									  where source.MemberType == MemberTypes.Property
									  select source;
			var commonMembers = targetMembers.Where(memberInfo => sourceMembers.Select(c => c.Name)
				.ToList().Contains(memberInfo.Name)).ToList();
			// Remove unwanted members
			commonMembers.RemoveWhere(x => x.Name.InList(excludeFields));
			foreach (var memberInfo in commonMembers)
			{
				if (!((PropertyInfo)memberInfo).CanWrite) continue;
				var targetProperty = typeof(T).GetProperty(memberInfo.Name);
				if (targetProperty == null) continue;
				var sourceProperty = myobj.GetType().GetProperty(memberInfo.Name);
				if (sourceProperty == null) continue;
				// Check source and target types are the same
				if (sourceProperty.PropertyType.Name != targetProperty.PropertyType.Name) continue;
				var value = myobj.GetType().GetProperty(memberInfo.Name)?.GetValue(myobj, null);
				if (value == null) continue;
				// Set the value
				targetProperty.SetValue(targetInstance, value, null);
			}
			return (T)targetInstance;
		}
