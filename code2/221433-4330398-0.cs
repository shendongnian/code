    public class Student : BaseClass
    {
        private string _school
        public string School 
        {
            get { return _school; }
            set
            {
                if(value == "Harvard")
                    value = "Harvard custom";
                _school = value;
            }
        }
        public String Country{ get; set; }
    }
