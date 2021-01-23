    class UserChoice
        {
            public string Year { get; set; }
    
            public Choice Choice { get; set; }
    
            public int UserId { get; set; }
    
            public UserChoice(string year, int userId, Choice choice )
            {
                Year = year;
                Choice = choice;
                UserId = userId;
            }
        }
    
        class Choice
        {
            
        }
