    public class User
    {
        [Required]
        public int UserID { get; set; }
    
        [Required]
        public string Login { get; set; }
        //one to many relationship
        public virtual Group Group { get; set; }
    }
    
    public class Group
    
        [Required]
        public int GroupID { get; set; }
    
        [Required]
        public string Name { get; set; }
    
        public virtual Group ParentGroup { get; set; }
    
        public virtual List<Group> ChildGroups { get; set; }
    
        [Required]
        public int UserId { get; set; }
        
        //If you want to lazy-load the user when you load the Group entity, use virtual
        //Then you don't need the .Include(g=>g.User)
        public virtual User CreatedBy { get; set; } //Not sure if this should be named 
                                                    //User or CreatedBy
    }
    
    public class OtherClass
    
        [Required]
        public int OtherClassID { get; set; }
    
        [Required]
        public int UserId { get; set; }
    
        public virtual User CreatedBy { get; set; }
    }
