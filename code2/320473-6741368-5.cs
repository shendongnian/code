    public object Clone()
    {
        MyClass copy = new MyClass();
        copy.List = List;//notice the difference here. This uses the same reference to the List object, so if this.List.Add it will add also to the copy list.
        
        return copy;
        //Note: Also return this.MemberwiseClone(); will do the same effect.
    }
