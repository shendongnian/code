    CultureInfo provider = new CultureInfo("ar-AE");    // Arabic - United Arab Emirates
    
    string sample = "الأربعاء 16 مارس 2011"; // Arabic date in Gregorian calendar
    DateTime result;
    DateTime expected = new DateTime(2011, 3, 16);   // the expected date
    bool b;
    
    b = DateTime.TryParse(sample, provider, DateTimeStyles.None, out result);
    
    Assert.IsTrue(b);
    Assert.AreEqual(expected, result);
