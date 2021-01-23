[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Account_Transaction", Storage="_Account", ThisKey="AccountId", OtherKey="AccountId", IsForeignKey=true)]
        public Account Account
        {
            get
            {
                return this._Account.Entity;
            }
            set
            {
                Account previousValue = this._Account.Entity;
                if (((previousValue != value) 
                            || (this._Account.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Account.Entity = null;
                        previousValue.Transactions.Remove(this);
                    }
                    this._Account.Entity = value;
                    if ((value != null))
                    {
                        value.Transactions.Add(this);
                        this._AccountId = value.AccountId;
                    }
                    else
                    {
                        this._AccountId = default(long);
                    }
                    this.SendPropertyChanged("Account");
                }
            }
        }
