    // This is a class to store information for a single task
    // It has nothing to do with a collection of tasks
    public class Task
    {
        private String _taskName;
        public String TaskName
        {
            get { return _taskName; }
            set { _taskName = value; }
        }
        private String _description;
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private Int32 _priority;
        public Int32 Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        public Task(String taskName, String description, Int32 priority)
        {
            this.TaskName = taskName;
            this.Description = description;
            this.Priority = priority;
        }
    }
    // This is a class that is a collection of Task types
    // Since it inherits from ObservableCollection, it is itself a collection
    // There is no need to declare/create an ArrayList inside.
    // And on a strict note, do not ever use ArrayList. It is obsolete and not strongly typed.
    // Use List<T>, ObservableCollection<T>, etc. instead.
    // Look for more Generic Collections in System.Collections.Generic namespace
    public class Tasks : ObservableCollection<Task>
    {
        public Tasks()
        {
            Add(new Task("A foo task", "doing foo", 1));
        }
    }
