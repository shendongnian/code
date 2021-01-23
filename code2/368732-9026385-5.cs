    public class RestValidationFailure : HttpResponseMessage
    {
        public RestValidationFailure(string[] messages)
        {
            StatusCode = HttpStatusCode.BadRequest;
            foreach (var errorMessage in messages)
            {
                Headers.Add("X-Validation-Error", errorMessage);
            }
        }
    }
