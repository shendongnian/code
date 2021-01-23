            dynamic person = new System.Dynamic.ExpandoObject();
            person.FirstName  = "John";
            person.LastName   = "Doe";
            person.Address    = "1234 Home St";
            person.City       = "Home Town";
            person.State      = "CA";
            person.Zip        = "12345";
            
            var writer = JsonFx.Json.JsonWriter();
            return writer.Write(person);
