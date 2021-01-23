        class Class1
        {
            // Fields
            private string _property1;       //Required for usage
            private List<object> _property2; //Not required for usage
            // Properties
            public string Property1
            {
                get
                {
                    Contract.Ensures(Contract.Result<string>() != null);
                    return this._property1;
                }
                set
                {
                    Contract.Requires(value != null);
                    this._property1 = value;
                }
            }
            public List<object> Property2
            {
                get
                {
                    Contract.Ensures(Contract.Result<List<object>>() != null);
                    return this._property2;
                }
                set
                {
                    Contract.Requires(value != null);
                    this._property2 = value;
                }
            }
            public Class1(string property1, List<object> property2)
            {
                Contract.Requires(property1 != null);
                Contract.Requires(property2 != null);
                this.Property1 = property1;
                this.Property2 = property2;
            }
            public Class1(string property1)
                : this(property1, new List<object>())
            {
                Contract.Requires(property1 != null);
            }
            [ContractInvariantMethod]
            private void ContractInvariants()
            {
                Contract.Invariant(_property1 != null);
                Contract.Invariant(_property2 != null);
            }
        }
