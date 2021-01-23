    public enum PersonState
    {
        None = 0,
        Archived = 1
        Deleted = 2
    }
    class Person
    {
        PersonState Status {get;set;}
    }
