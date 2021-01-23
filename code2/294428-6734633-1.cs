      using Dynamitey.DynamicObjects;
      ...
      dynamic New = Builder.New<ExpandoObject>();
      var person = New.Person(
          Name: New.Name(FirstName:"John", SurName:"Smith")
      );
