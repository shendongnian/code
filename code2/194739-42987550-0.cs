    public static bool IsTrue(string value)
    {
        // Avoid exceptions
        if (value == null)
            return false;
        // Remove whitespace from string and lowercase it.
        value = value.Trim().ToLower();
        return value == "true"
            || value == "t"
            || value == "1"
            || value == "yes"
            || value == "y";
    }
