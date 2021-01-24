    else if (context.Result is BadRequestObjectResult badRequestObjectResult)
            {
                System.Reflection.PropertyInfo pi = badRequestObjectResult.Value.GetType().GetProperty("Errors");
                Dictionary<string, string[]> errors = (Dictionary<string, string[]>)(pi.GetValue(badRequestObjectResult.Value, null));
              
                var errorMessages = errors.SelectMany(p => p.Value).Distinct();
                string message = string.Join(" | ", errorMessages);
    
                return new ReturnResult(false, ResultStatus.BadRequest, message);
            }
