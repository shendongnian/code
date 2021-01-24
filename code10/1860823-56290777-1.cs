    public static implicit operator ReturnResult(BadRequestObjectResult result)
            {
                System.Reflection.PropertyInfo pi = result.Value.GetType().GetProperty("Errors");
                Dictionary<string, string[]> errors = (Dictionary<string, string[]>)(pi.GetValue(result.Value, null));
                var message = result.ToString();
                var errorMessage = error.SelectMany(p => p.Value).Distinct();
                message = string.Join(" | ", errorMessage);
                return new ReturnResult(false, ResultStatus.BadRequest, message);
            }
