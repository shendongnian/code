    public class ValidationHandler : HttpOperationHandler
    {
        private readonly HttpOperationDescription _httpOperationDescription;
        private readonly Uri _baseAddress;
        public ValidationHandler(HttpOperationDescription httpOperationDescription, Uri baseAddress)
        {
            _httpOperationDescription = httpOperationDescription;
            _baseAddress = baseAddress;
        }
        protected override IEnumerable<HttpParameter> OnGetInputParameters()
        {
            return new[] { HttpParameter.RequestMessage };
        }
        protected override IEnumerable<HttpParameter> OnGetOutputParameters()
        {
            //Extension method that gets all the parameter types from the method for the current operation
            var types = _httpOperationDescription.GetParameterTypes(); 
            
            return types.Select(type => new HttpParameter(type.Name, type));
        }
        protected override object[] OnHandle(object[] input)
        {
            var request = (HttpRequestMessage)input[0];
            var uriTemplate = _httpOperationDescription.GetUriTemplate();
            var uriTemplateMatch = uriTemplate.Match(_baseAddress, request.RequestUri);
            var validationResults = new List<ValidationResult>();
            //Bind the values from uriTemplateMatch.BoundVariables to a model
            //Do the validation with Validator.TryValidateObject and add the results to validationResults
            //Throw a exception with BadRequest http status code and add the validationResults to the message
            //Return the bound model if no validation errors occured
        }
    }
