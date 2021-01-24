    public class UserToDo
    {
        [Key]
        public string UserEmail { get; set; }
        [Key] // add this to create a composite key
        public int ToDoId { get; set; }
    }
