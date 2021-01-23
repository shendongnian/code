    class UpdateLogoParameters
    {
        public byte[] Logo{get;set;}
        public int DocumentId{get;set;}
    
        public UpdateLogoParameters(byte[] logo, int documentId)
        {
           Logo = logo;
           DocumentId = documentId;
        }
    }
