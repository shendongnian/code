    public class MyClass
    {
        public string Forename{get;set;}
        public string Surname{get;set;}
        //etc
    }
    var usersInfo = from c in _dataModel.UserProfile select new MyClass{ c.Forname, c.Surname, c.aspnet_Users.UserName, c.Countries.CountryName, c.Specialities.SpecialityName};
