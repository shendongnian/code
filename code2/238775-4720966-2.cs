    namespace test
    {
        public unsafe struct MutableFoo
        {
            public int Id;
            public float X;
            public MutableFoo(int id, float x) { Id = id; X = x; }
            public void Change(float x)
            {
                unsafe
                {
                    fixed (MutableFoo* self = &(this))
                    {
                        MutabilityHelper.Rewrite(self, x);
                    }
                }
            }
        }
    
        public struct NotReallyImmutableFoo
        {
            public long Id;
            public readonly float X;
            public NotReallyImmutableFoo(long id, float x) { Id = id; X = x; }
            public void Change(float x)
            {
                unsafe
                {
                    fixed (NotReallyImmutableFoo* self = &(this))
                    {
                        MutabilityHelper.Rewrite(self, x);
                    }
                }
            }
        }
    
        // this calls breaks up the immutability rule, because we are modifying structures itself
        public static class MutabilityHelper
        {
            struct MutableFooPrototype
            {
                int Id;
                float X;
                public void Rewrite(float value)
                {
                    X = value;
                }
            }
            struct NotReallyImmutableFooPrototype
            {
                long Id;
                float X;
                public void Rewrite(float value)
                {
                    X = value;
                }
            }
            public static unsafe void Rewrite(NotReallyImmutableFoo* obj, float value)
            {
                NotReallyImmutableFooPrototype* p_obj = (NotReallyImmutableFooPrototype*)(*(&obj));
                p_obj->Rewrite(value);
            }
            public static unsafe void Rewrite(MutableFoo* obj, float value)
            {
                MutableFooPrototype* p_obj = (MutableFooPrototype*)(*(&obj));
                p_obj->Rewrite(value);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                MutableFoo foo = new MutableFoo(0, 2);
                foo.X = 3; // X is writeable
                foo.Change(5); // write X using pointer prototyping
    
                NotReallyImmutableFoo nrifoo = new NotReallyImmutableFoo(0, 2);
                // error CS0191
                //nrifoo.X = 3; // X is not writeable
                nrifoo.Change(3); // anyway, write X using pointer prototyping
            }
        }
    }
