        public class ViewModel
        {
            #region property
            public Dictionary<string, Model_Sport> Sports { get; set; }
            public DelegateCommand SportsResponseCommand { get; set; }
            #endregion
            public ViewModel()
            {
                Sports = new Dictionary<string, Model_Sport>();
                SportsResponseCommand = new DelegateCommand(p => execute_SportsResponseCommand(p));
                buildSports();
            }
            private void buildSports()
            {
                Model_Sport football = new Model_Sport("Football", SportsResponseCommand);
                Model_Sport golf = new Model_Sport("Golf", SportsResponseCommand);
                Model_Sport hockey = new Model_Sport("Hockey", SportsResponseCommand);
            
                football.IsChecked = true; // just for test
                Sports.Add(football.Name, football);
                Sports.Add(golf.Name, golf);
                Sports.Add(hockey.Name, hockey);
            }
            private void execute_SportsResponseCommand(object p)
            {
                // TODO :what ever you want
                MessageBox.Show(p.ToString());
            }
        }
