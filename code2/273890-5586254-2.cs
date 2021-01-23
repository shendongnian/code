	public static class TypeHelper {
		public static ConstructorInfo GetDefaultConstructor<TType>() {
			var type = typeof(TType);
			return type.GetDefaultConstructor();
		}
		
		public static ConstructorInfo GetDefaultConstructor(this Type type) {
			if(type == null) throw new ArgumentNullException("type");
			var constructor = type.GetConstructor(Type.EmptyTypes);
			if(constructor == null) {
				var ctors = 
					from ctor in type.GetConstructors()
					let prms = ctor.GetParameters()
					where prms.All(p=>p.IsOptional)
					orderby prms.Length
					select ctor;						
				constructor = ctors.FirstOrDefault();
			}
			return constructor;
		}
	}
