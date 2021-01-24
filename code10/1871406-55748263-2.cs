    public class RequestValidationService : IRequestValidationService
    {
        public ValidationResult ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token) || token != "1234")
            {
                return new ValidationResult
                {
                    Succeeded = false,
                    Message = "invalid token",
                    StatusCode = 403
                };
            }
            return new ValidationResult { Succeeded = true };
        }
        ...
    }
