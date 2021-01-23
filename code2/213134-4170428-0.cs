    DataTable dt = GetData();
             var dataRows = dt.AsEnumerable();
             //Initializing the evaluator  
             Evaluator.Init(new string[0]); 
              Evaluator.ReferenceAssembly(Assembly.GetAssembly(typeof(DataRow)));
              Evaluator.ReferenceAssembly(Assembly.GetExecutingAssembly());
             Evaluator.Run(@"using System;  
               using System.Linq;  
               using System.Collections.Generic;
               using System.Data;
               using MyNamespace;");
             var func = (Func<DataRow, object>)Evaluator.Evaluate(@"new Func<DataRow,object>(z => new
                    {
                        make = z[""make""],
                        model = z[""model""]
                    });");
             dataRows.GroupBy(func).Select(x => x.Key);
