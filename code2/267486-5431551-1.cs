        [Table(Name = "Transaction")]
        public partial class Transaction
        {
            private decimal _amount;   
            private int _id
            private DateTime _payDate;
            private int _currencyId;
          
            private EntityRef<Currency> _currencyMaster;
            
            partial void OnLoaded();
            partial void OnValidate(System.Data.Linq.ChangeAction action);
            partial void OnCreated();        
    
            public Transaction()
            {            
                _currencyMaster = default(EntityRef<Currency>);
                OnCreated();
            }
    
           [Column(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
            public int Id
            {
                get
                {
                    return _id;
                }
                protected set
                {
                    if ((_id != value))
                    {
                        OnPropertyChanging();
                        _id = value;
                        OnPropertyChanged("Id");
                    }
                }
            }
           
            [Column(Storage = "_amount", DbType = "Decimal(18,2) NOT NULL", UpdateCheck = UpdateCheck.Never)]
            public decimal Amount
            {
                get
                {
                    return _amount;
                }
                set
                {
                    if ((_amount != value))
                    {
                        OnPropertyChanging();
                        _amount = value;
                        OnPropertyChanged("Amount");
                    }
                }
            }
            
            [Column(Storage = "_currencyId", DbType = "INT NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
            public int CurrencyId
            {
                get
                {
                    return _currencyId;
                }
                set
                {
                    if ((_currencyId != value))
                    {
                        OnPropertyChanging();
                        _currencyId = value;
                        OnPropertyChanged("CurrencyId");
                    }
                }
            }
         
            [Column(Storage = "_payDate", DbType = "DateTime NOT NULL", UpdateCheck = UpdateCheck.Never)]
            public DateTime PayDate
            {
                get
                {
                    return _payDate;
                }
                set
                {
                    if ((_payDate != value))
                    {
                        OnPropertyChanging();
                        _payDate = value;
                        OnPropertyChanged("PayDate");
                    }
                }
            }
            
            [Association(Name = "Transaction_Currency", Storage = "_currencyMaster", ThisKey = "CurrencyId", OtherKey = "Id", IsForeignKey = true)]
            public Currency Currency
            {
                get
                {
                    return _currencyMaster.Entity;
                }
                set
                {
                    Currency previousValue = _currencyMaster.Entity;
                    if (((previousValue != value)
                                || (_currencyMaster.HasLoadedOrAssignedValue == false)))
                    {
                        OnPropertyChanging();
                        if ((previousValue != null))
                        {
                            _currencyMaster.Entity = null;
                            previousValue.Transactions.Remove(this);
                        }
                        _currencyMaster.Entity = value;
                        if ((value != null))
                        {
                            value.Transactions.Add(this);
                            _currencyId = value.Id;
                        }
                        else
                        {
                            _currencyId = default(int);
                        }
                        OnPropertyChanged("Currency");
                    }
                }
            }
    
            
        }
    
        
