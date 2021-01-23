    public class MyClass
    {
        public string Forename{get;set;}
        public string Surname{get;set;}
        //etc
    }
    var usersInfo = from c in _dataModel.UserProfile select new MyClass{ Forename=c.Forname, Surname=c.Surname, ...};
