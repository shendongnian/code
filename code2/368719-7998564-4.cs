     public class ValidationHandler<T> : HttpOperationHandler
     {
        private readonly HttpOperationDescription _httpOperationDescription;
        public ValidationHandler(HttpOperationDescription httpOperationDescription) 
        {
            _httpOperationDescription = httpOperationDescription;
        }
        protected override IEnumerable<HttpParameter> OnGetInputParameters()
        {
            return _httpOperationDescription.InputParameters
                .Where(prm => prm.ParameterType == typeof(T));
        }
        protected override IEnumerable<HttpParameter> OnGetOutputParameters()
        {
            return _httpOperationDescription.InputParameters
                .Where(prm => prm.ParameterType == typeof(T));
        }
        protected override object[] OnHandle(object[] input)
        {
            var model = input[0];
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, context, validationResults,true);
            if (validationResults.Count == 0)
            {
                return input;
            }
            else
            {
                var response = new HttpResponseMessage() 
                { 
                    Content = new StringContent("Model Error"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }
        }
    }
