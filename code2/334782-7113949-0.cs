    public void ValidateName()
    {
        if (_customer.Name.Length < 5) {
            LogValidationFailure("shortName");  // you can add more params if needed
            return; // or return false if you need it
        }
        // do normal business here
    }
