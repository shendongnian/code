        public Form1()
        {
            InitializeComponent();
            // Call DrawDropDown with:
            //   The clicked ToolStripSplitButton
            //   "Undo" as the action
            //   TestDropDown for the enumerable string source for the list box
            //   UndoCommands for the click callback
            toolStripSplitButton1.DropDownOpening += (sender, e) => { DrawDropDown(
                toolStripSplitButton1,
                "Undo",
                TestDropDown,
                UndoCommands
            ); };
        }
        private IEnumerable<string> TestDropDown
        {
            // Provides a list of strings for testing the drop down
            get { for (int i = 1; i < 1000; ++i) { yield return "test " + i; } }
        }
        private void UndoCommands(int count)
        {
            // Do something with the count when an action is clicked
            Console.WriteLine("Undo: {0}", count);
        }
