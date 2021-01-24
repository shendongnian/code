    public static IEnumerable<object[]> GetUserChoiceTestData() 
    {
        yield return new object[] { MockData.Current.Choices[0], "It is a book" };
        yield return new object[] { MockData.Current.Choices[1], "It is a pen" };
    }
