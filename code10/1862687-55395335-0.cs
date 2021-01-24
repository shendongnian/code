    class Section
    {
        string sectionName;
        public List<Student> students;
        //probably more properties need to be implemented, or at least would make life simpler
        public Section(string sectionName)
        {
            this.sectionName = sectionName;
            students = new List<Student>();
            List<Assignment> assignments = new List<Assignment>();
        }    
    }
