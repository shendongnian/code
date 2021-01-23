    public class Job
    {
        private Comment jobComment;
        public string Comment
        {
            get { return this.jobComment.Text; }
            set { this.jobComment.Text = value; }
        }
        public string Name { get; set; }
    }
    public class Employee
    {
        private Comment employeeComment;
        public string Comment
        {
            get { return this.employeeComment.Text; }
            set { this.employeeComment.Text = value; }
        }
        public string Name { get; set; }
    }
