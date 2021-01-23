    public static class class1
    {
        public void Run()
        {
            class2.Mode mode = class2.Mode.Selected;
            if (mode == class2.Mode.Selected)
            {
                // Do something crazy here...
            }
        }
    }
    public static class class2
    {
        public enum Mode
        { 
            Selected, 
            New
        } 
    }
