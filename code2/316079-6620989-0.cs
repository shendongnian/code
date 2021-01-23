    public class PeopleCollection
    {
        public people[] People;
        public class people
        {
            public string IdentityCode;
            public string Firstname;
            public string Surname;
        }
    }
    public class ForCompare : IEqualityComparer<PeopleCollection.people>
    {
        string _fieldName = "";
       
        public ForCompare(string fieldName)
        {
            _fieldName = fieldName;
        }
        public bool Equals(PeopleCollection.people a, PeopleCollection.people b)
        {
            return "IdentityCode".Equals(_fieldName) ? true : a.GetType().GetProperty(_fieldName).GetValue(a, null).Equals(b.GetType().GetProperty(_fieldName).GetValue(b, null));
        }
        public int GetHashCode(PeopleCollection.people a)
        {
            return a.GetHashCode();
        }
    }
