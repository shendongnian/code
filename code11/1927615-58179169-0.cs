      public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                List<string> states = new List<string>() { "State1", "state2" };//This should contain all the states 
                foreach (var state in states)
                {
                    listStates.Items.Add(state);
                }
            }
        }
