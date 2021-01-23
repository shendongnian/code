	AppDomain domain = AppDomain.CurrentDomain;
	AssemblyName aName = new AssemblyName("DynamicEnums");
	AssemblyBuilder ab = domain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Save);
	ModuleBuilder mb = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");
	// Store a handle to the ReferenceObject(int32 pValue)
	// constructor.
	ConstructorInfo referenceObjectConstructor = typeof(ReferenceObject).GetConstructor(new[] { typeof(int) });
	foreach (ReferenceType rt in GetTypes())
	{
		TypeBuilder tb = mb.DefineType(rt.Name, TypeAttributes.Public);
		// Define a static constructor to populate the ReferenceObject
		// fields.
		ConstructorBuilder staticConstructorBuilder = tb.DefineConstructor(MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, Type.EmptyTypes);
		ILGenerator staticConstructorILGenerator = staticConstructorBuilder.GetILGenerator();
		foreach (Reference r in GetReferences(rt.ID))
		{
			string name = r.Abbreviation.Trim();
			// Create a public, static, readonly field to store the
			// named ReferenceObject.
			FieldBuilder referenceObjectField = tb.DefineField(name, typeof(ReferenceObject), FieldAttributes.Static | FieldAttributes.Public | FieldAttributes.InitOnly);
			// Add code to the static constructor to populate the
			// ReferenceObject field:
			// Load the ReferenceObject's ID value onto the stack as a
			// literal 4-byte integer (Int32).
			staticConstructorILGenerator.Emit(OpCodes.Ldc_I4, r.ID);
			// Create a reference to a new ReferenceObject on the stack
			// by calling the ReferenceObject(int32 pValue) reference
			// we created earlier.
			staticConstructorILGenerator.Emit(OpCodes.Newobj, referenceObjectConstructor);
			// Store the ReferenceObject reference to the static
			// ReferenceObject field.
			staticConstructorILGenerator.Emit(OpCodes.Stsfld, referenceObjectField);
		}
		// Finish the static constructor.
		staticConstructorILGenerator.Emit(OpCodes.Ret);
		tb.CreateType();
	}
	ab.Save(aName.Name + ".dll");
