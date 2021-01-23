    public bool Equals(MyClass item1, MyClass item2)
    {
        if(object.ReferenceEquals(item1, item2))
            return true;
        if(item1 == null || item2 == null)
            return false;
        return item1.MyString1.Equals(item2.MyString1) &&
               item1.MyString2.Equals(item2.MyString2);
    }
