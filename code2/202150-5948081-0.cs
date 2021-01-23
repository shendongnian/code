    public class MyEntity
    {
        private string _name;
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if(value != this._name)
                {
                      this._name = vaule;
                      this.RaisePropertyChanged("Name");
                }
            }
    }
