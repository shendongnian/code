    class Person : IBiographicalData, ICustomReportData
    {
        private string lastName;
    
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    
        public string ICustomReportData.LastName
        {
            get { return "Last Name:" + lastName; }
            set { lastName = value; }
        }
    }
     
  
