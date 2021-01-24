    foreach (var ms in modelState.Keys)
        {
            var value = modelState[ms];
            foreach (ModelError error in value.Errors)
            {
                sb.AppendLine(error.ErrorMessage);
            }
            if (!string.IsNullOrEmpty(value.Value.AttemptedValue)) { 
                sb.AppendLine($"Attempted Value: {value.Value.AttemptedValue}");
            }
        }
