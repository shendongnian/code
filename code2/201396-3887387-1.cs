    namespace MVCApplication.Models
    {
        public class Person
        {
            private int _ID;
            private string _Name;
            ...
            public Person() {}
            public int ID { get{ return _ID } set{ this._ID = value } }
            public int Name { get{ return _Name } set{ this._Name = value } }
            ...
        }
    }
