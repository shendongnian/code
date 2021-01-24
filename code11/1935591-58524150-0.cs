    public class Employee
    {
        ...
        [InverseProperty(nameof(Task.RequestedBy))]
        public ICollection<Task> RequestedTasks { get; set; }
        [InverseProperty(nameof(Task.TaskedTo))]
        public ICollection<Task> AssignedTasks { get; set; }
    }
