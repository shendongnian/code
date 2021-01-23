    [Export]
    public class CircleDrawer
    {
        [Import("Config")]
        public Func<string,string> ConfigGetter { get; set; }
    
        public void Draw()
        {
            string configuration = this.ConfigGetter("Circle");
            ...
        }
    }
