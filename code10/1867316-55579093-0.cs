    [Serializable()]
     public class DematerialisationException : Exception
    {
        private static readonly string DefaultMessage = "An error occurred during dematerialisation.";
    
        public DematerialisationException() : base(DefaultMessage)
        { }
    
        public DematerialisationException(string message) : base(message) 
        { }
    
        public DematerialisationException(Exception inner) : base (DefaultMessage, inner)
        { }
    
        public DematerialisationException(string message, Exception inner) : base (message, inner)
        { }
    }
