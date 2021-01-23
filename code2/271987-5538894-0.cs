    public void Problem(DateTime? optional = null)
    {
       DateTime dateTime = optional != null ? optional.Value : DateTime.MaxValue;
       // Now use dateTime
    }
