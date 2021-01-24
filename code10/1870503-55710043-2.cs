    class MyItem
    {
        public string ProperlyNamedProperty1{get;set;}
        ...
        public MyItem(string prop1,string prop2,...)
        {
            ProperlyNamedProperty1=prop1;
            ...
        }
    }
    var  _optoGrid = new List<MyItem>{
        new MyItem("10",     "10",     "100",     "20",    "10",     "10"),
    };
    var orderedResults=_optoGrid.OrderBy(item=>item.Property6);
