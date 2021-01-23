    [Export(typeof(IDrawer))]
    public class CircleDrawer : IDrawer
    {
        [Import("Config")]
        public Func<string,string> ConfigGetter { get; set; }
    
        public void Draw()
        {
            string configuration = this.ConfigGetter("Circle");
            ...
        }
    }
