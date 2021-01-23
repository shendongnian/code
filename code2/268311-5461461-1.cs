    // update the constraint to match the new WebServiceResult definition
    public abstract class WebServiceResultParser<T> where T : WebServiceResult<T>
    {
        T result;
        public WebServiceResultParser(T result)
        {
            this.result = result;
        }
    
        protected abstract bool Parse(String response);
        private bool ParseHttpResponse(HttpWebResponse httpWebResponse)
        {
            //some logic to get http response as string
            var http_response_as_string = httpWebResponse.ToString();
            result.GetParser().Parse(http_response_as_string);
            return true;
        }
    }
    
    // move the type constraint from the GetParser() method to the class itself
    public abstract class WebServiceResult<T> where T : WebServiceResult<T>
    {
        protected internal abstract WebServiceResultParser<T> GetParser();
    }
    
    // no change
    public class RegistrationResultParser : WebServiceResultParser<RegistrationResult>
    {
        private RegistrationResult result;
        public RegistrationResultParser(RegistrationResult result)
            : base(result)
        {
            this.result = result;
        }
    
        protected override bool Parse(String response)
        {
            //some logic to extract customer number
            //result.CustomerNumber = customerNumber;
            return true;
        }
    }
    
    // explicitly specify the constraint on the base class (which is used to
    // specify the GetParser() return type)
    public class RegistrationResult : WebServiceResult<RegistrationResult>
    {
        public String CustomerNumber { get; internal set; }
    
        protected internal override WebServiceResultParser<RegistrationResult> GetParser()
        {
            return new RegistrationResultParser(this);
        }
    }
