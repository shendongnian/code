    public static bool PropertyCheck(Type theTypeOfTheAimedProperty, string aString)
    {
       // Checks to see if the value passed is valid.
       return TypeDescriptor.GetConverter(typeof(theTypeOfTheAimedProperty))
                .IsValid(aString);
    }
