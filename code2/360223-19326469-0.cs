    public static class GenTest93
    {
        public interface IThingUser<T> { void ActOnThing(T it); }
        class StructUser<T> : IThingUser<T>, IThingUser<Nullable<T>> where T : struct
        {
            void IThingUser<T>.ActOnThing(T it) { System.Diagnostics.Debug.Print("Struct {0}", typeof(T)); }
            void IThingUser<Nullable<T>>.ActOnThing(T? it) { System.Diagnostics.Debug.Print("Struct? {0}", typeof(T)); }
        }
        class ClassUser<T> : IThingUser<T> where T : class
        {
            void IThingUser<T>.ActOnThing(T it) { System.Diagnostics.Debug.Print("Class {0}", typeof(T)); }
        }
        static class ThingUsers<T>
        {
            class DefaultUser : IThingUser<T>
            {
                public void ActOnThing(T it)
                {
                    Type t = typeof(T);
                    if (t.IsClass)
                        t = typeof(ClassUser<>).MakeGenericType(typeof(T));
                    else
                    {
                        if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
                            t = t.GetGenericArguments()[0];
                        t = typeof(StructUser<>).MakeGenericType(t);
                    }
                    TheUser = (IThingUser<T>)Activator.CreateInstance(t);
                    TheUser.ActOnThing(it);
                }
            }
            static IThingUser<T> TheUser = new DefaultUser();
            public static void ActOnThing(T it) {TheUser.ActOnThing(it);}
        }
        public static void ActOnThing<T>(T it) { ThingUsers<T>.ActOnThing(it); }
        public static void Test()
        {
            int? foo = 3;
            ActOnThing(foo);
            ActOnThing(5);
            ActOnThing("George");
        }
    }
