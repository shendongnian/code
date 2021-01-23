    public class Project
    {
        public int ProjectId {get; set;}
        public virtual Employee Employee {get;set;}
        public void RemoveEmployee()
        {
            Employee = null;
        }
    }
