    // move the type constraint from the method to the class
    public abstract class WebServiceResult<T> where T : WebServiceResult
    {
       protected internal abstract WebServiceResultParser<T> GetParser<T>() 
    }
    
    // specify the constraint in your concrete class definition
    public class RegistrationResult : WebServiceResult<RegistrationResult>
    {
        public String CustomerNumber { get; internal set; }
    
        protected internal override
            WebServiceResultParser<RegistrationResult> GetParser<RegistrationResult>()
        {
            return new RegistrationResultParser(this);
        }
    }
