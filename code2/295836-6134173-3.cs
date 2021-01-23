    public class Submission 
    {
        		        	
        public Submission() {}
        private int submissionId;
        public int SubmissionId 
        { 
            get{ return this.submissionId; }
            set{ this.submissionId = value; }
        }
        private int custId ;
        public int CustId
        { 
            get{ return this.custId ; }
            set{ this.custId = value; }
        }
        private int broId ;
        public int BroId
        { 
            get{ return this.broId ; }
            set{ this.broId = value; }
        }
        private int coverage;
        public int Coverage
        { 
            get{ return this.coverage; }
            set{ this.coverage= value; }
        }
    } 
