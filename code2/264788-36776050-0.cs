    // You can do something like this.
    [TestMethod]
    public void PhoneNumberIsValid
    {
        var propInfo = typeof(Person).GetProperty("PhoneNumber");
        var attr = propInfo.GetCustomAttributes(typeof(RegularExpressionAttribute), true);
        
        // Act Assert Positives
            Assert.IsTrue(((RegularExpressionAttribute)attr [0]).IsValid("555-55-5555"));
               
            // Act Assert Negative
          Assert.IsFalse(((RegularExpressionAttribute)attr[0]).IsValid("123654654654"));
            
            }
