    public static void AreEqual<T>(T expected, T actual, string message, params object[] parameters)
    {
        if (!object.Equals(expected, actual))
        {
            string str;
            if (((actual != null) && (expected != null)) && !actual.GetType().Equals(expected.GetType()))
            {
                str = (string) FrameworkMessages.AreEqualDifferentTypesFailMsg((message == null) ? string.Empty : ReplaceNulls(message), ReplaceNulls(expected), expected.GetType().FullName, ReplaceNulls(actual), actual.GetType().FullName);
            }
            else
            {
                str = (string) FrameworkMessages.AreEqualFailMsg((message == null) ? string.Empty : ReplaceNulls(message), ReplaceNulls(expected), ReplaceNulls(actual));
            }
            HandleFail("Assert.AreEqual", str, parameters);
        }
    }
 
