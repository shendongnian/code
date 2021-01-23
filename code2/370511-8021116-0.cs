            var objs= new PSDataCollection<CustomObj> {obj};
            using (var ps = PowerShell.Create())
            {
                ps.Runspace.SessionStateProxy.SetVariable("objList", objs);
                ps.AddScript(@"$objList| ForEach { $_.Run()}");
                ps.AddCommand("Out-String");
                var output = ps.Invoke();
                var stringBuilder = new StringBuilder();
                foreach (var obj in output)
                {
                    stringBuilder.AppendLine(obj.ToString());
                }
                var result = stringBuilder.ToString().Trim();
                  
                //Evaluate result.
            }
