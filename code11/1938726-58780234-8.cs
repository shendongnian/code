lang-js
$suite = [MyCmdLets.Suite]::New("suite1")
$suite | Add-Set "type1" "desc1"`
       | Add-Option "color1" "place1"`
       | Add-Option "color2" "place2" | Out-Null
To do so, follow these steps:
1. Create a C# class Library Project (for example name it `MyCmdlets`)
2. Install Package `Microsoft.PowerShell.5.ReferenceAssemblies`
3. Create your model classes, independent from PowerShell. (See the code at the bottom of post)
4. Create the cmdlets considering the following notes: (See the code at the bottom of post)
 * Per each cmdlet, create a C# class
 * Derive from `CmdLet` class
 * Decorate the class with `Cmdlet` attribute specifying the verb and the name after verb, for example if you want to have `Add-Set`, use `[Cmdlet(VerbsCommon.Add, "Set")]`.
 * If you want to have an output for pipeline, decorate the class with `OutputType` attribute specifying the type of output, for example if you want to have an output of type `Set` for the pipeline, use `[OutputType(typeof(Set))]`.
 * Per each input parameter of your cmdlet, define a C# property.
 * Decorate each parameter property by `Parameter` attribute.
 * If you want to accept a parameter from pipeline, when decorating with `Parameter` attribute, set `ValueFromPipeline` to true, fro example `[Parameter(ValueFromPipeline =true)`
5. Build the project.
6. Open PowerShell ISE and run the following code:
        Import-Module "PATH TO YOUR BIN DEBUG FOLDER\MyCmdlets.dll"
       
        $suite = [MyCmdLets.Suite]::New("suite1")
        $suite | Add-Set "type1" "desc1"`
               | Add-Option "color1" "place1"`
               | Add-Option "color2" "place2" | Out-Null
 It will create a structure like this:
        Name   Sets           
        ----   ----           
        suite1 {MyCmdlets.Set}
        Type  Description Options                             
        ----  ----------- -------                             
        type1 desc1       {MyCmdlets.Option, MyCmdlets.Option}
        Color  Place 
        -----  ----- 
        color1 place1
        color2 place2
    
**Model Classes**
Design your model classes independent from PowerShell like this:
    using System.Collections.Generic;
    namespace MyCmdlets
    {
        public class Suite
        {
            public string Name { get; set; }
            public List<Set> Sets { get; } = new List<Set>();
            public Suite(string name) {
                Name = name;
            }
        }
        public class Set
        {
            public string Type { get; set; }
            public string Description { get; set; }
            public List<Option> Options { get; } = new List<Option>();
            public Set(string type, string description) {
                Type = type;
                Description = description;
            }
        }
        public class Option 
        {
            public string Color { get; set; }
            public string Place { get; set; }
            public Option(string color, string place) {
                Color = color;
                Place = place;
            }
        }
    }
**CmdLet Classes**
Designe the cmdlet classes based on notes which I describe above:
    using System.Management.Automation;
    namespace MyCmdlets
    {
        [Cmdlet(VerbsCommon.Add, "Set"), OutputType(typeof(Set))]
        public class AddSetCmdlet : PSCmdlet
        {
            [Parameter(ValueFromPipeline = true, Mandatory = true)]
            public Suite Suite { get; set; }
            [Parameter(Position = 0, Mandatory = true)]
            public string Type { get; set; }
            [Parameter(Position = 1, Mandatory = true)]
            public string Description { get; set; }
            protected override void ProcessRecord() {
                var set = new Set(Type, Description);
                Suite.Sets.Add(set);
                WriteObject(set);
            }
        }
        [Cmdlet(VerbsCommon.Add, "Option"), OutputType(typeof(Option))]
        public class AddOptionCmdlet : PSCmdlet
        {
            [Parameter(ValueFromPipeline = true, Mandatory = true)]
            public Set Set { get; set; }
            [Parameter(Position = 0, Mandatory = true)]
            public string Color { get; set; }
            [Parameter(Position = 1, Mandatory = true)]
            public string Place { get; set; }
            protected override void ProcessRecord() {
                var option = new Option(Color, Place);
                Set.Options.Add(option);
                WriteObject(Set);
            }
        }
    }
