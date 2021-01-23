    public class B
    {
        public string Name;
    }
    public class A
    {
        public EventHandler TypedEvent;
        public void MyMethod(B item)
        {
            if (TypedEvent != null)
            {
                TypedEvent(item, null);
            }
        }
    }
    public class T
    {
        public void Run()
        {
            A item = new A();
            item.TypedEvent += new EventHandler(ItemEvent);
        }
        private void ItemEvent(object sender, EventArgs e)
        {
            B b = sender as B;
            b.Name = "Loaded";
        }
    }
