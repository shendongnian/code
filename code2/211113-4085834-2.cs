        abstract class Setter<T>
        {
            public abstract void Set(T obj, object value);
        }
        class Setter<TTarget, TValue> : Setter<TTarget>
        {
            private readonly Action<TTarget, TValue> del;
            public Setter(MethodInfo method)
            {
                del = (Action<TTarget, TValue>)
                    Delegate.CreateDelegate(typeof(Action<TTarget, TValue>), method);
            }
            public override void Set(TTarget obj, object value)
            {
                del(obj, (TValue)value);
            }
        }
        static Action<T, object> MakeSetterDelegate<T>(PropertyInfo property)
        {
            MethodInfo setMethod = property.GetSetMethod();
            if (setMethod != null && setMethod.GetParameters().Length == 1)
            {
                Setter<T> untyped = (Setter<T>) Activator.CreateInstance(
                    typeof(Setter<,>).MakeGenericType(typeof(T),
                    property.PropertyType), setMethod);
                return untyped.Set;
            }
            else
            {
                return null;
            }
        }
