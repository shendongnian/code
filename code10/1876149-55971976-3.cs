    class User
    {
        public int Id {get; set;}
        public string Name {get; set;}
        // every User has zero or more Hobbies (many-to-many)
        public virtual ICollection<Hobby> Hobbies {get; set;}
        // every Student has created zero or more events (one-to-many)
        public virtual ICollection<CreatedEvent> CreatedEvents {get; set;}
        ...
    }
        
    class Hobby
    {
        public int Id {get; set;}
        public string Name {get; set;}
        ...
        // every Hobby is practised by zero or more Users (many-to-many)
        public virtual ICollection<User> Users {get; set;}
    }
    class CreatedEvent
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public DateTime Date {get; set;}
        // every event is created by exactly one User (one-to-many, using foreign key)
        public int UserId {get; set;}
        public virtual User User {get; set;}
    }
