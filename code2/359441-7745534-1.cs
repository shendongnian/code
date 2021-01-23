     public static void execute(String condition = "Unnamed condition",
            List<String> messages = null, Object actual = null,
            Object expected = null)
    {
        // assuming you are using messages once for iteration or something...
        foreach(var msg in messages ?? Enumerable.Empty<String>())
        ...
    }
