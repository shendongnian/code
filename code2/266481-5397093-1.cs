    class Treenodebase<T> where T : Treenodebase<T>
    {
        public T Parent{get;set;}
        public IEnumerable<T> Children {get;set;}
    }
    class Specialtreenode : Treenodebase<Specialtreenode>
    {
        string SpecialProperty{get;set;}
        public string ParentsSpecialProperty()
        {
            return Parent.SpecialProperty;
        }
    }
