    static void Main(string[] args)
    {
        var peoples = new PersonCollection();
        var julie = new Person("Julie", 23, 45)
        peoples.Add(julie);
        people.Remove(julie);
        //  - or -
        people.Remove("Julie");
    }
