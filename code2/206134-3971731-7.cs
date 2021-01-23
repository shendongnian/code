    public string TestService()
    {
        if (Authentication == null) {
            return "Access is denied";
        }
        // ... the rest of your code
