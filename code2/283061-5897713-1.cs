    public ValidationResult ValidateCommand(MakeCustomerGold command)
    {
        var result = new ValidationResult();
        if (Customer.CanMakeGold(command.CustomerId))
        {
            // "OK" logic here
        } else {
            // "Not OK" logic here
        }
    }
