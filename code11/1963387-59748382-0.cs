    List1e.Should().BeEquivalentTo(List2e);
- Move all the individual comparisons to the `.Equals` method (Or implement `IEqualityComparer`)
- Build a helper method that iterates through public properties by reflection and assert each property
      public static void PropertyValuesAreEquals(object actual, object expected)   {
        PropertyInfo[] properties = expected.GetType().GetProperties();
        foreach (PropertyInfo property in properties)
        {
            object expectedValue = property.GetValue(expected, null);
            object actualValue = property.GetValue(actual, null);
          if (!Equals(expectedValue, actualValue))
                Assert.Fail("Property {0}.{1} does not match. Expected: {2} but was: {3}", property.DeclaringType.Name, property.Name, expectedValue, actualValue);
	//……………………………….
        }
- Use JSON to compare the object’s data
    public static void AreEqualByJson(object expected, object actual)
    {
       var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
       var expectedJson = serializer.Serialize(expected);
       var actualJson = serializer.Serialize(actual);
       Assert.AreEqual(expectedJson, actualJson);
    }
- [Property Constraints][2] (NUnit 2.4.2)
  [1]: https://fluentassertions.com/objectgraphs/
  [2]: https://nunit.org/docs/2.6.4/propertyConstraint.html
