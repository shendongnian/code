            MethodBuilder setPropMthdBldr =
                tb.DefineMethod("set_" + "TestProperty",
                  MethodAttributes.Public |
                  MethodAttributes.SpecialName |
                  MethodAttributes.HideBySig,
                  null, new Type[] { propertyType });
            ConstructorInfo ctor1 = typeof(ValidationContext).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                                                                             null,
                                                                             new Type[]{
                                                                                    typeof(Object),
                                                                                    typeof(IServiceProvider),
                                                                                    typeof(IDictionary<object, object>)},
                                                                             null);
            MethodInfo method2 = typeof(ValidationContext).GetMethod("set_MemberName",
                                                                     BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                                                                     null,
                                                                     new Type[]{typeof(String)},
                                                                     null);
            MethodInfo method3 = typeof(Validator).GetMethod("ValidateProperty",
                                                             BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
                                                             null,
                                                             new Type[]{
                                                                    typeof(Object),
                                                                    typeof(ValidationContext)},
                                                             null);
            ILGenerator setIL = setPropMthdBldr.GetILGenerator();
            setIL.DeclareLocal(typeof(System.ComponentModel.DataAnnotations.ValidationContext));
            setIL.Emit(OpCodes.Nop);
            setIL.Emit(OpCodes.Ldarg_1);
            setIL.Emit(OpCodes.Box, typeof(Int32));  //in this case it's int32, should be your property type
            setIL.Emit(OpCodes.Ldarg_0);
            setIL.Emit(OpCodes.Ldnull);
            setIL.Emit(OpCodes.Ldnull);
            setIL.Emit(OpCodes.Newobj, ctor1);
            setIL.Emit(OpCodes.Stloc_0);
            setIL.Emit(OpCodes.Ldloc_0);
            setIL.Emit(OpCodes.Ldstr, "TestProperty");
            setIL.Emit(OpCodes.Callvirt, method2);
            setIL.Emit(OpCodes.Nop);
            setIL.Emit(OpCodes.Ldloc_0);
            setIL.Emit(OpCodes.Call, method3);
            setIL.Emit(OpCodes.Nop);
            setIL.Emit(OpCodes.Ldarg_0);
            setIL.Emit(OpCodes.Ldarg_1);
            setIL.Emit(OpCodes.Stfld, fieldBuilder);  //the fieldbuilder you are using to define the private field
            setIL.Emit(OpCodes.Ret);
