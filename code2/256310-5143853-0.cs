    public class Registration
        {
            public static Registration Instance = new Registration();
            private Registration()
            {
            }
            private Dictionary<Type, object> Dictionary = new Dictionary<Type, object>();
            public void Register<T>(Func<T, uint> aFunc)
            {
                Dictionary[typeof(T)] = aFunc;
            }
            public uint GetId<T>(T aT)
            {
                var f = Dictionary[typeof(T)];
                var g = (Delegate)f;
                return (uint) g.DynamicInvoke(aT);
            }
        }
