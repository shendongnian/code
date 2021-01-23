            var objs = new List<ExpandoObject>();
            for (var i = 0; i < 10; i++)
            {
                dynamic eObj = new ExpandoObject();
                eObj.Property = i;
                objs.Add(eObj);
            }
            foreach (dynamic obj in objs)
            {
                obj.Property2 = "bubuValue" + obj.Property;
                obj.Property3 = "bubuValue" + obj.Property2;
            }
            foreach (dynamic obj in objs)
            {
                Console.WriteLine(obj.Property3);
            }
