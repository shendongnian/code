    public partial class SettingsForm : Form
    {
        private bluRemote _remote = new bluRemote();  // possibly created somewhere else
        
        public void SomeFunction() 
        {
            if (_remote.cableOrSat == "CABLE")
            {
                 _remote.cableOrSat = "SAT";
            }
        }
        .......
    }
