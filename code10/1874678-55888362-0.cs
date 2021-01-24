    public class UserToDo
    {
        [Key]
        public string UserEmail { get; set; }
        public int ToDoId { get; set; }
        public ToDo ToDo { get; set; }
    }
