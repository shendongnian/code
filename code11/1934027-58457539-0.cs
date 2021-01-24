        if (value != null)
            {
                if (Regex.Matches(((string)value),@"[*&%#@$^!]").Count > 0)
                {
                 return new ValidationResult("Notes contains unacceptable characters");
                }
            }
