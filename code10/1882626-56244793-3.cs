    class User
    {
        public int Id {get; set;}
        ... // other properties
        // every User has zero or more "From" messages (one-to-many)
        public virtual ICollection<Message> FromMessages {get; set;}
        
        // every user has zero or more "To" message (one-to-many)
        public virtual ICollection<Message> ToMessages {get; set;}
    }
    class Message
    {
        public int Id {get; set;}
        ... // other properties
        // every Message has exactly one "From" user using foreign key FromUserId
        public int FromUserId {get; set;}
        public virtual User From {get; set;}
        // every Message has exactly one "To" user using foreign key ToUserId
        public int ToUserId {get; set;}
        public virtual User To {get; set;}
    }
