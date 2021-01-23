    class BasePanel
    {
        public virtual void Draw(string blah)
        {
            Console.WriteLine("Base: " + blah);
        }
    }
    class UIButton : BasePanel
    {
        public override void Draw(string blah)
        {
            Console.WriteLine("UIButton: " + blah);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<BasePanel> list = new List<BasePanel>();
            list.Add(new BasePanel());
            list.Add(new UIButton());
            list.Add(new BasePanel());
            list.Add(new UIButton());
            list.Add(new UIButton());
            foreach (var b in list)
            {
                b.Draw("just a string");
            }
        }
    }
