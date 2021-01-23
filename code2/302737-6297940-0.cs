    public class ParameterBuilder: UserControl
    {
        private ObservableCollection<UserParameter> parameters = new ObservableCollection<UserParameter>();
    
        // Don't make it a dependency property
        public ObservableCollection<UserParamter> Parameters
        {
            get { return this.parameters; }
        }
    }
