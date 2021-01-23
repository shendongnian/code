       string classname = "TestClass";
        // add a class
        Button1.Attributes.Add("class", String.Join(" ", Button1
                   .Attributes["class"]
                   .Split(' ')
                   .Except(new string[]{"",classname})
                   .Concat(new string[]{classname})
                   .ToArray()
           ));
         //remove a class
         Button1.Attributes.Add("class", String.Join(" ", Button1
                   .Attributes["class"]
                   .Split(' ')
                   .Except(new string[]{"",classname})
                   .ToArray()
           ));
