            Dictionary<string, string> variables = new Dictionary<string, string>();
            if (line.Trim().ToUpper().StartsWith("SET"))
            {
                List<string> commandLine;
                commandLine = line.Trim(' ',';').Split().Distinct().ToList();
                commandLine.Remove(string.Empty);
                // After next line, the 'variables' dictionary contains the name 
                // of the variable you want to set, and its value
                variables[commandLine[1]] = commandLine[3];
                // ...
                // Do something here (try catch, chatever, but NO MySqlCommand)
                // ...
            }
            else
            {
                // If the line contains any of the variables you previously set,
                // i will be the index of this variable, -1 otherwise
                int i = line.ContainsAnyOfAt(variables.Keys);
                if (i>=0)
                {
                    // Here we replace the parameter by its value, for example:
                    // UPDATE `creature` SET `guid`=@newguid WHERE `guid`=@oldguid;
                    // becomes:
                    // UPDATE `creature` SET `guid`=202602 WHERE `guid`=250006;
                    line = line.Replace(variables.Keys.ElementAt(i), variables.Values.ElementAt(i));
                }
                // ...
                // This is where you should put the code of MySqlCommand
                // ...
            }
