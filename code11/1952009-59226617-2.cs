        class Actions { }
        class Adapter { }
        class Button : Adapter { }
        
        // covariant generic interface
        interface IActionElement<out T> where T : Adapter
        {
            T GetAdapter();
        }
        // covariant generic interface implementation
        class ActionElement<T> : IActionElement<T> where T : Adapter
        {
            T adapter;
            public T GetAdapter()
            {
                return adapter;
            }
            public ActionElement(T adapter)
            {
                this.adapter = adapter;
            }
        }
        class Pineapple
        {
            IActionElement<Adapter> actionElement;
            Queue<Actions> queue;
            // note that I'm using the IActionElement interface here. Not the class that implements the interface like you do
            public Pineapple Given(IActionElement<Adapter> adapter)
            {
                actionElement = adapter;
                queue = new Queue<Actions>();
                return this;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                // now it works
                Pineapple pineapple = new Pineapple();
                var pineappleClone = pineapple.Given(new ActionElement<Button>(new Button()));
            }
        }
