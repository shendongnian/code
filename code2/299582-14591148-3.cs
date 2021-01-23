    [Test]
    [TestCase("123 123 1adc \n 222", "1231231adc222")]
    public void RemoveWhiteSpace1(string input, string expected)
    {
        string s = null;
        for (int i = 0; i < 1000000; i++)
        {
            s = input.RemoveWhitespace();
        }
        Assert.AreEqual(expected, s);
    }
    [Test]
    [TestCase("123 123 1adc \n 222", "1231231adc222")]
    public void RemoveWhiteSpace2(string input, string expected)
    {
        string s = null;
        for (int i = 0; i < 1000000; i++)
        {
            s = Regex.Replace(input, @"\s+", "");
        }
        Assert.AreEqual(expected, s);
    }
