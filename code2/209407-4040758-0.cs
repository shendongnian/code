    public class Company : IEntity
    {
        public string Name
        {
          get { return _Name; }
          set { _Name = value; }
        }
        private string _Name;
    }
