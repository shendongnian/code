                //instantiate your List<string> from reading the path
                List<string> lines = System.IO.File.ReadAllLines(path).ToList<string>();
                //use a line index to check where you're at
                int lineIndex = 0;
               
                //I'd use foreach loops in C# .. they're really nice
                foreach (string line in lines)
                {
                   //split the line to get the fields
                    var lineSplit = line.Split(',');
                    //if the first part is your account number then we can edit it
                    if (lineSplit[0] == account.AccountNumber.ToString())
                    {
                        //replace any one of these with a new value
                        var _accountNumber = lineSplit[0];
                        var _name = lineSplit[1];
                        var _balance = lineSplit[2];
                        var _type = lineSplit[3].ToString().Substring(0, 1);
                        //then put the newline back into a string var
                        string newline = _accountNumber + "," + _name + "," + _balance + "," + _type + "\r\n";
                        //assign the string back into our list at the index point
                        lines[lineIndex] = newline;
                    }
                    //add one to the index
                    lineIndex++;
                }
                //then write back to your file
                System.IO.File.WriteAllLines(pathNew, lines);
