    class Test
    {
       public int Id { get; set; }
       public User User {get; set;}
    }
    
    cnn.Query("select * from Tests where Id = @Id", new Test{Id = 1}); // used to go boom 
