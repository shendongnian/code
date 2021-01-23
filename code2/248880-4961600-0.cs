    public abstract class Collaborator : IPersonInformation, IRecruitmentInformation
    {
        private string firstName;
        public String FirstName
        { 
            get { return firstName; }
            set 
            {
    
                //validation code
    
                this.firstName = value;
            }
        }
        public String LastName { get; set; }
        public DateTime RecruitmentDate { get; set; } 
    }
