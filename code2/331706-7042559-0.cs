    using IronPython.Hosting;
    using IronPython.Runtime;
    
    //Script Engine Reference
    using Microsoft.Scripting.Hosting;
    //Source Code Kind Reference
    using Microsoft.Scripting;
    
    //Iron Python Reference
    using IronPython.Hosting;
    using IronPython.Runtime;
    //Source Execute
    using Microsoft.CSharp;
    
                ScriptEngine engine = Python.CreateEngine();
                ScriptRuntime runtime = engine.Runtime;
                ScriptScope scope = runtime.CreateScope();
    
                //Simple Example
    
                string code = @"emp.Salary * 0.3";
    
    
                ScriptSource source =
                  engine.CreateScriptSourceFromString(code, SourceCodeKind.Expression);
    
    
                var emp = new Employee { Id = 1000, Name = "Bernie", Salary = 1000 };
    
    
                scope.SetVariable("emp", emp);
    
    
                var res = (double)source.Execute(scope);
    
                MessageBox.Show(res.ToString());
   
     public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Salary { get; set; }
    
    
        }
