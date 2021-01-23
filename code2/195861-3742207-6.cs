       string classname = "TestClass";
        // Add a class
        Button1.Attributes.Add("class", String.Join(" ", Button1
                   .Attributes["class"]
                   .Split(' ')
                   .Except(new string[]{"",classname})
                   .Concat(new string[]{classname})
                   .ToArray()
           ));
         // Remove a class
         Button1.Attributes.Add("class", String.Join(" ", Button1
                   .Attributes["class"]
                   .Split(' ')
                   .Except(new string[]{"",classname})
                   .ToArray()
           ));
