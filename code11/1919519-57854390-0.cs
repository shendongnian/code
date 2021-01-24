<Button Command="{Binding AddScoreCommand}" IsEnabled="{Binding isEnable}"/>
###in ViewModel
    public class SubmitDataViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand AddScoreCommand { get; set; }
        private bool isenable;
        public bool isEnable
        {
            get
            {
                return isenable;
            }
            set
            {
                if (isenable != value)
                {
                    isenable = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public SubmitDataViewModel()
        {
            //...
            isEnable = true; // set the default value
        }
        private async void CmdSubData()
        {
            //Scorelist contains data that is displayed in the form that needs 
            //to be submitted
            foreach (var element in Scorelist)
            {
                var _scoreDef = new scores
                {
                    ID = element.ID,
                    SCORES = element.SCORES, //Gets entered value from entry
                    GOAL_ID = element.ID,
                };
                response = await apiServices.SubmitScore(_scoreDef);
            }
            isEnable = false; // change the value after submit 
        }
    }
