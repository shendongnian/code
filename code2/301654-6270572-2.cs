    public class Submission 
    {
            // consider implementing the below as properties to more finely control access
            public int SubmissionId;
            public int Status;
            public string StatusComment;
            public Customer SubmissionCustomer; // <-- this is null until you set it to a Customer object, either in the constructor or externally.
            public Submission() {
              // constructor
            }
    }
