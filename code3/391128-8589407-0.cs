    class MyClass
    {
        public int Class {get;set;}
        public int Group {get;set;}
        public string Name {get;set;}
        public string SurName {get;set;}
    }
    var result = from row in dt.AsEnumerable()
                          select new MyClass
                           {
                            Class=row.Field<int>("class"),
                            Group=row.Field<int>("group"),
                            Name=row.Field<string>("name"),
                            SurName=row.Field<string>("surname")
                            };
             
  
