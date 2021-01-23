    public class B
    {
        public string Name;
    }
    public class A
    {
        public EventHandler<B> TypedEvent;
        public void MyMethod(B item)
        {
            if (TypedEvent != null)
            {
                TypedEvent(null, item);
            }
        }
    }
    public class T
    {
        public void Run()
        {
            A item = new A();
            item.TypedEvent += new EventHandler<B>(ItemEvent);
        }
        private void ItemEvent(object sender, B b)
        {
            b.Name = "Loaded";
        }
    }
