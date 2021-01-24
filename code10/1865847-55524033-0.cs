c#
        public class JsonSchemaController : ApiController
    {
        [HttpPost]
        [Route("api/jsonschema/validate")]
        public ValidateResponse Valiate(ValidateRequest request)
        {
            // load schema
            JSchema schema = JSchema.Parse(request.Schema);
            JToken json = JToken.Parse(request.Json);
    
            // validate json
            IList<ValidationError> errors;
            bool valid = json.IsValid(schema, out errors);
    
            // return error messages and line info to the browser
            return new ValidateResponse
            {
                Valid = valid,
                Errors = errors
            };
        }
    }
    
    public class ValidateRequest
    {
        public string Json { get; set; }
        public string Schema { get; set; }
    }
    
    public class ValidateResponse
    {
        public bool Valid { get; set; }
        public IList<ValidationError> Errors { get; set; }
    }
  [1]: https://www.jsonschemavalidator.net/
