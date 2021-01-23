    private static object GetValueForPropertyOrField( object objectThatContainsPropertyName, IEnumerable<string> properties )
      {
         foreach ( var property in properties )
         {
            Type typeOfCurrentObject = objectThatContainsPropertyName.GetType();
            var parameterExpression = Expression.Parameter( typeOfCurrentObject, "obj" );
            Expression memberExpression = Expression.PropertyOrField( parameterExpression, property );
            var expression = Expression.Lambda( Expression.GetDelegateType( typeOfCurrentObject, memberExpression.Type ), memberExpression, parameterExpression ).Compile();
            objectThatContainsPropertyName = expression.DynamicInvoke( objectThatContainsPropertyName );
         }
         return objectThatContainsPropertyName;
      }
      [TestMethod]
      public void TestOneProperty()
      {
         var dateTime = new DateTime();
         var result = GetValueForPropertyOrField( dateTime, new[] { "Day" } );
         Assert.AreEqual( dateTime.Day, result );
      }
      [TestMethod]
      public void TestNestedProperties()
      {
         var dateTime = new DateTime();
         var result = GetValueForPropertyOrField( dateTime,  new[] { "Date", "Day" } );
         Assert.AreEqual( dateTime.Date.Day, result );
      }
      [TestMethod]
      public void TestDifferentNestedProperties()
      {
         var dateTime = new DateTime();
         var result = GetValueForPropertyOrField( dateTime, new[] { "Date", "DayOfWeek" } );
         Assert.AreEqual( dateTime.Date.DayOfWeek, result );
      }
