      static T CastByExample<T>(object target, T example) {
        return (T)target;
      } 
      // .....
      var example = new { ContactID = 0, FullName = "" };
      foreach (var o in GetContactInfo()) {
        var c = CastByExample(o, example);
        Console.WriteLine(c.ContactID);
      }
