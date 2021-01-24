    public class TaskGroup
    {
        public string Key { get; set; }
        public Lists<TaskViewModel> Tasks { get; set; }
    }
    public class TaskViewModel
    {
        public string Name { get; set; }
        public string Assignee { get; set; }
        // rest of the properties
    }
