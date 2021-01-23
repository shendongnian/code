		public static Action<object, object> CreateSetter(FieldInfo field)
		{
			DynamicMethod dm = new DynamicMethod("DynamicSet", typeof(void),
				new Type[] { typeof(object), typeof(object) }, field.DeclaringType, true);
			ILGenerator generator = dm.GetILGenerator();
			generator.Emit(OpCodes.Ldarg_0);
			generator.Emit(OpCodes.Ldarg_1);
			if (field.FieldType.IsValueType)
				generator.Emit(OpCodes.Unbox_Any, field.FieldType);
			generator.Emit(OpCodes.Stfld, field);
			generator.Emit(OpCodes.Ret);
			return (Action<object, object>)dm.CreateDelegate(typeof(Action<object, object>));
		}
