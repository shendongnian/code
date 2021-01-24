    if (context != null)
    {
        switch (context.ModelMetadata.PropertyName)
        {
            case "TermsAccepted":
                if (!context.Model.TermsAccepted) {
                    return new ModelValidationResult[]
                    {
                        new ModelValidationResult 
                        {
                            MemberName = "TermsAccepted",
                            Message = "You must accept the terms"
                        }
                    };
                }
                break; 
            default:
        }
        return new List<ModelValidationResult> 
        {
            new ModelValidationResult("", ErrorMessage)
        };
    }
    return Enumerable.Empty<ModelValidationResult>();
}
~~~
