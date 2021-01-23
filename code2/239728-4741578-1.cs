    interface IPerson
    {
        ICollection<string> NickNames{get;set;}
    }
    class ObservablePerson : IPerson
    {
        ICollection<string> NickNames{get;set;}
    }
    class ListPerson : IPerson
    {
        ICollection<string> NickNames{get;set;}
    }
