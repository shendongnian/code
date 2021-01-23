    public class Teams : INotifyPropertyChanged
    {
        private string Combined; // Backing for CombinedTeams
        public string CombinedTeams
        {
            get
            {
                return Combined;
            }
            set
            {
                // This only concatinates values; Combined will get longer each time.
                Combined += value;
                // ViewModels should always notify after the vale has changed
                NotifyOfPropertyChange("CombinedTeams");
            }
        }
        // Adds a new team, assuming HomeTeam, HomeScore, AwayScore, and AwayTeam have been initialized
        public void AddTeam()
        {
            CombinedTeams = " " + HomeTeam + " " + HomeScore + " - " + AwayScore + " " + AwayTeam;              
        }                     
    }
