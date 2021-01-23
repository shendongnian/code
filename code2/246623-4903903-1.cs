    void Main(...)
    {
        var list = new List<Student>();
        Student s = new Student(...);
        list.Add(s);
    
        list.Remove(s); //removes 's' if it is in the list based on the result of the .Equals method
    
        list.RemoveAt(0); //removes the item at index 0, use the first example if possible/appropriate
    }
