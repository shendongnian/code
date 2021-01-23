    // BusinessEntityBase is what allows us to
    // use MVC Data Annotations ( http://bit.ly/18NCpJU )
    public class MyModel : BusinessEntityBase
    {
        private string _name;
        private List<Action> _validationQueue = new List<Action>();
        private Timer _timer = new Timer { Interval = 500 };
        [Required( AllowEmptyStrings = false )]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                var currentValue = this._name;
                this._name = value;
                base.RaisePropertyChanged("Name");
                
                this.AddValidationAction( "Name", currentValue, value  );
            }
        }
        private void AddValidationAction<T>( string Name,  T currentValue, T newValue)
        {
            Action validationAction = 
                () => 
                    base.SetPropertyValue( Name, ref currentValue, newValue );
            _validationQueue.Add(validationAction);
            this._timer.Enabled = true;
        }
        private void ProcessValidationQueue(object sender, ElapsedEventArgs e)
        {
            if( _validationQueue.Count > 0 )
            {
                while ( _validationQueue.Count > 0)
                {
                    _validationQueue[0].Invoke();
                    _validationQueue.RemoveAt( 0 );
                }
            }
            this._timer.Enabled = false;
        }
        public MyModel()
        {
            _timer.Enabled = false;
            _timer.Elapsed += this.ProcessValidationQueue;
            _timer.Start();
        }
    }
