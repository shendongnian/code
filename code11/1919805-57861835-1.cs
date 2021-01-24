<#@ template debug="true" hostspecific="true" language="C#" #>
<#@ assembly name="System.Core" #>
<#@ import namespace="System.Linq" #>
<#@ import namespace="System.Text" #>
<#@ import namespace="System.Collections.Generic" #>
<#@ import namespace="System.IO" #>
<#@ output extension=".cs" #>
using System;
using System.Collections.Generic;
namespace Model
{<#Go();#>}
<#+
    void Go()
    {
        Dictionary<string /*modelName*/, string[] /*properties*/> modelDict = new Dictionary<string, string[]>();
        //... read the dictionary ...
        foreach(var model in modelDict)
        {
            WriteLine("   class " + model.Key + "\r\n" +
                      "   {\r\n");
            foreach(var prop in model.Value)
                WriteLine("      public string " + prop + " {get; set;}\r\n");
            WriteLine("   }\r\n\r\n");
        }
    }
#>
Save this to a *.tt file in your project and it should create a *.cs file.
