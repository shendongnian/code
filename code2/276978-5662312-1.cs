    class Person : IBiographicalData, ICustomReportData
    {
        private string lastName;
    
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
