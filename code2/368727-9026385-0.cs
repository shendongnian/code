    public class ValidationHandler<TResource> : HttpOperationHandler<TResource, HttpRequestMessage, HttpRequestMessage>
    {
        public ValidationHandler() : base("response") { }
        protected override HttpRequestMessage OnHandle(TResource model, HttpRequestMessage requestMessage)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, context, results, true);
            if (results.Count == 0)
            {
                return requestMessage;
            }
            var errorMessages = results.Select(x => x.ErrorMessage).ToArray();
            var mediaType = requestMessage.Headers.Accept.FirstOrDefault();
            var response = new RestValidationFailure(errorMessages);
            if (mediaType != null)
            {
                response.Content = new ObjectContent(typeof (string[]), errorMessages, mediaType);
            }
            throw new HttpResponseException(response);
        }
    }
