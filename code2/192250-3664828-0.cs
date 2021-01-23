    public class Drawer
    {
        private ITool _tool;
        public Drawer(ITool tool, IPattern pattern)
        {
            _tool = new Tool(pattern);
        }
        ...
    }
    public class Tool : ITool
    {
        private IPattern _pattern;
        
        public Tool(IPattern pattern)
        {
            _pattern = pattern;
        }
        ...
    }
