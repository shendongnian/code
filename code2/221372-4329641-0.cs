    dynamic script = CSScript.LoadCode(@"using System;
                                     public class Script
                                     {
                                         public void SayHello(string greeting)
                                         {
                                             Console.WriteLine(greeting);
                                         }
                                     }")
                                    .CreateObject("*");
    script.SayHello("Hello World!");
