    public class SomeClassViewModel
    {
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string Emails { get; set; }
        public string EmailsCSV
        {
            get
            {
                var csv = Emails;
                //Do CSV transform here
                return csv;
            }
        }
        public string EmailsCRLF
        {
            get
            {
                var crlf = Emails;
                //Do crlf transform here
                return crlf;
            }
        }
    }
