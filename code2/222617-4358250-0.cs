        static void Main(string[] args)
        {
            Derived foo = new Derived();
            foo.Foo();
            MethodInfo method = typeof(Base).GetMethod("Foo");
            DynamicMethod dm = new DynamicMethod("BaseFoo", null, new Type[] { typeof(Derived) }, typeof(Derived));
            ILGenerator gen = dm.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_1);
            gen.Emit(OpCodes.Call, method);
            gen.Emit(OpCodes.Ret);
            var BaseFoo = (Action<Derived>)dm.CreateDelegate(typeof(Action<Derived>));
            BaseFoo(foo);
            Console.ReadKey();
        }
