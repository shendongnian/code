        string classname = "TestClass";
        // add a class
        BtnventCss.CssClass = String.Join(" ", Button1
                   .CssClass
                   .Split(' ')
                   .Except(new string[]{"",classname})
                   .Concat(new string[]{classname})
                   .ToArray()
           );
         //remove a class
         BtnventCss.CssClass = String.Join(" ", Button1
                   .CssClass
                   .Split(' ')
                   .Except(new string[]{"",classname})
                   .ToArray()
           );
