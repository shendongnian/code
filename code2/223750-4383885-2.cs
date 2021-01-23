public override string this[string columnName]
{
    get
    {
        // Let the base implementation run the DataAnnotations validators
        var error = base[columnName];
        // If no error reported, run my custom one-off validations for this
        // view model here
        if (string.IsNullOrWhiteSpace(error))
        {
            switch (columnName)
            {
                case "Password":
                    if (this.Password == "password")
                    {
                        error = "See an administrator before you can log in.";
                    }
                    break;
            }
        }
        return error;
    }
