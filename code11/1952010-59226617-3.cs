        class BaseClass { }
        class DerivedClassA : BaseClass { }
        class DerivedClassB : BaseClass { }
        interface ISomeObject<in T> where T : BaseClass
        {
            void SetClass(T clazz);
        }
        class SomeRealObject<T> : ISomeObject<T> where T : BaseClass
        {
            T obj;
            public void SetClass(T obj)
            {
                this.obj = obj;
            }
        }
