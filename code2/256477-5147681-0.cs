    public class Product: IRecord, IDataErrorInfo, INotifyPropertyChanged
    {
        // events
        public event PropertyChangedEventHandler PropertyChanged;
    
        // properties
        private int _id;
        public virtual int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
    
        private string _name;
        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
    
        // parameterless constructor (always useful for serialization, winforms databinding, etc.)
        public Product()
        {
            ProductId = 0;
            Name = String.Empty;
        }
    
        // update methods
        public virtual void Save()
        {
           ValidateThrow();
           ... do save (insert or update) ...
        }
        
        public virtual void Delete()
        {
           ... do delete ...
        }    
        
        // validation methods
        public string Validate()
        {
           return Validate(null);
        }
        
        private void ValidateThrow()
        {
          List<Exception> exceptions = new List<Exception>();
          SummaryValidate(exceptions,memberName);
          if (exceptions.Count != 0)
             throw new CompositeException(exceptions);
        }
    
        public string Validate(string memberName)
        {
          List<Exception> exceptions = new List<Exception>();
          SummaryValidate(exceptions,memberName);
          if (exceptions.Count == 0)
            return null;
            
          return ConcatenateAsString...(exceptions);
        }
        
        string IDataErrorInfo.Error
        {
          get
          {
             return Validate();
          }
        }
    
        string IDataErrorInfo.this[string columnName]
        {
          get
          {
            return validate(columnName);
          }
        }
        
        public virtual void SummaryValidate(IList<Exception> exceptions, string memberName)
        {
           if ((memberName == null) || (memberName == "Name"))
           {
             if (!... validate name ...)
                exceptions.Add(new ValidationException("Name is invalid");
           }
        }
    
        protected void OnPropertyChanged(string name)
        {
           OnPropertyChanged(new PropertyChangedEventArgs(name));
        }
        
        // property change notification
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if ((PropertyChanged != null)
                PropertyChanged(this, e);
        }
    
        // read from database methods
        protected virtual Read(IDataReader reader)
        {
          Id = reader.GetInt32(reader.GetOrdinal("Id"));
          Name = = reader.GetString(reader.GetOrdinal("Id"));
          ...
        }
        
        void IRecord.Read(IDataReader reader)
        {
          Read(reader);
        }
        
        // instance creation methods
        public static Product GetById(int id)
        {
            // possibly use some cache (optional)
            Product product = new Product();
            using (IDataReader reader = GetSomeReaderForGetById...(id))
            {
                if (!reader.Read())
                  return null;
    
                ((IRecord)product).Read(reader);
                return product;
            }
        }
    
        public static List<Product> GetAll()
        {
            // possibly use some cache (optional)
            List<Product> products = new List<Product>(); // if you use WPF, an ObservableCollection would be more appropriate?
            using (IDataReader reader = GetSomeReaderForGetAll...(id))
            {
                while (reader.Read())
                {
                  Product product = new Product();
                  ((IRecord)product).Read(reader);
                  products.Add(product);
                }
            }
            return products;
        }
    }
    
    // an interface to read from a data record (possibly platform independent)
    public interface IRecord
    {
      void Read(IDataReader reader);
    }
