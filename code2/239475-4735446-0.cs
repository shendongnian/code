      var objs = new List<ExpandoObject>();
            for (var i = 0; i < 10; i++)
            {
                dynamic eObj = new ExpandoObject();
                eObj.Proeprty = i;
            }
            foreach (dynamic obj in objs)
            {
                obj.Property2 = "bubuValue";
                obj.Property3 = "bubuValue";
            }
