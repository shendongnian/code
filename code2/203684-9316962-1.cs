    using System;
    public class CreateObject
    {
        public static object CreatePropertyObject(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>> objData)
        {
            System.Collections.Generic.Dictionary<string, Type> list = new System.Collections.Generic.Dictionary<string, Type>();
            foreach (var o in objData)
            {
                list.Add(o.Key, o.Value.GetType());
            }
            Type newType = BuildPropertyObject(list);
            object newObject = NewPropertyObject(newType, objData);
            return newObject;
        }
        public static object NewPropertyObject(Type newType, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>> objData)
        {
            var newObject = Activator.CreateInstance(newType);
            foreach (var item in objData)
            {
                // Set the value on the new object
                newObject.GetType().GetProperty(item.Key).SetValue(newObject, item.Value, null);
            }
            return newObject;
        }
        public static Type BuildPropertyObject(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Type>> obj)
        {
            string nameOfDLL = "magic.dll";
            string nameOfAssembly = "magic_Assembly";
            string nameOfModule = "magic_Module";
            string nameOfType = "magic_Type";
            System.Reflection.AssemblyName assemblyName = new System.Reflection.AssemblyName { Name = nameOfAssembly };
            System.Reflection.Emit.AssemblyBuilder assemblyBuilder = System.Threading.Thread.GetDomain().DefineDynamicAssembly(assemblyName, System.Reflection.Emit.AssemblyBuilderAccess.RunAndSave);
            System.Reflection.Emit.ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(nameOfModule, nameOfDLL);
            System.Reflection.Emit.TypeBuilder typeBuilder = moduleBuilder.DefineType(nameOfType, System.Reflection.TypeAttributes.Public | System.Reflection.TypeAttributes.Class);
            foreach (var prop in obj)
            {
                string Name = prop.Key;
                Type DataType = prop.Value;
                System.Reflection.Emit.FieldBuilder field = typeBuilder.DefineField("_" + Name, DataType, System.Reflection.FieldAttributes.Private);
                System.Reflection.Emit.PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(Name, System.Reflection.PropertyAttributes.SpecialName, DataType, null);
                System.Reflection.MethodAttributes methodAttributes = System.Reflection.MethodAttributes.Public | System.Reflection.MethodAttributes.HideBySig | System.Reflection.MethodAttributes.SpecialName;
                System.Reflection.Emit.MethodBuilder methodBuilderGetter = typeBuilder.DefineMethod("get_" + Name, methodAttributes, DataType, new Type[] { });
                System.Reflection.Emit.MethodBuilder methodBuilderSetter = typeBuilder.DefineMethod("set_" + Name, methodAttributes, typeof(void), new Type[] { DataType });
                System.Reflection.Emit.ILGenerator ilGeneratorGetter = methodBuilderGetter.GetILGenerator();
                ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
                ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Ldfld, field);
                ilGeneratorGetter.Emit(System.Reflection.Emit.OpCodes.Ret);
                System.Reflection.Emit.ILGenerator ilGeneratorSetter = methodBuilderSetter.GetILGenerator();
                ilGeneratorSetter.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
                ilGeneratorSetter.Emit(System.Reflection.Emit.OpCodes.Ldarg_1);
                ilGeneratorSetter.Emit(System.Reflection.Emit.OpCodes.Stfld, field);
                ilGeneratorSetter.Emit(System.Reflection.Emit.OpCodes.Ret);
                propertyBuilder.SetGetMethod(methodBuilderGetter);
                propertyBuilder.SetSetMethod(methodBuilderSetter);
            }
            // Yes! you must do this, it should not be needed but it is!
            Type dynamicType = typeBuilder.CreateType();
       
            // Save to file
            assemblyBuilder.Save(nameOfDLL);
            return dynamicType;
        }
    }
