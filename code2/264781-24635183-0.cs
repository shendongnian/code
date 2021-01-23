    [TestMethod]
    public void Test_Regex_NationalinsuranceNumber()
    {
        var regularExpressionAttribute = new RegularExpressionAttribute(Constants.Regex_NationalInsuranceNumber_Validate);
        List<string> validNINumbers = new List<string>() { "TN311258F", "QQ123456A" };
        List<string> invalidNINumbers = new List<string>() { "cake", "1234", "TS184LZ" };
        validNINumbers.ForEach(p => Assert.IsTrue(regularExpressionAttribute.IsValid(p)));
        invalidNINumbers.ForEach(p => Assert.IsFalse(regularExpressionAttribute.IsValid(p)));
    }
