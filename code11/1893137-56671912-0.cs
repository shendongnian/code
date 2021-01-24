        class Program
        {
            public class YourObjectType {
                public void DoSomething() { }
            }
            public class WeakReferences {
                public WeakReference<Action> a;
                public WeakReference<YourObjectType> o;
            }
            static WeakReferences createReferences() {
                var someObj = new YourObjectType();
                return new WeakReferences() { a = new WeakReference<Action>((Action)someObj.DoSomething), o = new WeakReference<YourObjectType>(someObj) };
            }
            static void Main(string[] args)
            {
                WeakReferences wr = createReferences();
                YourObjectType o = null;
                wr.o.TryGetTarget(out o); //comment this line to collect it instead
                GC.Collect();
                Action a = null;
            
                Console.WriteLine(wr.a.TryGetTarget(out a));
                Console.WriteLine(wr.o.TryGetTarget(out o));
                Console.ReadLine();
            }
        }
