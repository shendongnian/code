    // Public.cs
    public class Public
    {
        private Form1 _ui;
        public Public(Form1 ui) { _ui = ui };
        public string MyFunction(int num_val)
        {
             if (_ui.IsNumberRequested)
             {
                  // Stuff
             }
             // Else, default Stuff
        }
    }
