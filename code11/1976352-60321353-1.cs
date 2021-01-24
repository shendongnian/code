     class Test_ViewModel
     {
            private IList<Test_Model> _comboData;
           
            public Test_ViewModel()
            {
                _comboData = dt.AsEnumerable().
                    Select(row => new Test_Model
                    {
                        Col1 = row.Field<string>(0),
                        Col2 = row.Field<string>(1)
                    }).ToList();
            }
                
            public IList<Test_Model> ComboData
            {
                get { return _comboData; }
                set { _comboData = value; }
            }
      }
