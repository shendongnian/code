            Dictionary<string, Type> props = new Dictionary<string,Type>();
            props["Id"] = typeof(int);
            props["Name"] = typeof(string);
            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("AsemName"), AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder mb = ab.DefineDynamicModule("ModuleName");
            TypeBuilder typeBuilder = mb.DefineType("TypeName");
            foreach(var name in props.Keys){
                typeBuilder.DefineField(name, props[name], FieldAttributes.Public);
            }
            Type type = typeBuilder.CreateType();
            object o = type.GetConstructor(Type.EmptyTypes).Invoke(null);
            //Verfication:
            Console.WriteLine("Type is: " + o.GetType());
            foreach (var field in o.GetType().GetFields())
            {
                Console.WriteLine(" " + field.Name + " of type " + field.ReflectedType);
            }
