    public class ApiInputModel
    {
        public MyStatusEnum[] Status {get; set;}
    }
    
    public class ApiInputModelDTO
    {
        // May be better to add an enum here to validate that the user is only inputting "InProgress" and "Completed".
        public string Status {get; set;}
    }
