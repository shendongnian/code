    // this is what you call to sort.
    myClass.Sort(MyClass.NameComparison);
    // This would sit in your class which you referenced as "MyClass"
    public static NameComparison<MyClass> NameComparison
    {
        get
        {
            return delegate(MyClass c1, MyClass c2)
            {
                return c1.Name.CompareTo(c2.Name);
            };
        }
    }
