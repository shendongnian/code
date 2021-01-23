        string classname = "TestClass";
        // Add a class
        BtnventCss.CssClass = String.Join(" ", Button1
                   .CssClass
                   .Split(' ')
                   .Except(new string[]{"",classname})
                   .Concat(new string[]{classname})
                   .ToArray()
           );
         // Remove a class
         BtnventCss.CssClass = String.Join(" ", Button1
                   .CssClass
                   .Split(' ')
                   .Except(new string[]{"",classname})
                   .ToArray()
           );
