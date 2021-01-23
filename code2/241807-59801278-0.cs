    foreach (string thisParameter in args)
                {
                    if (thisParameter.Contains("="))
                    {
                        string parameter = thisParameter.Substring(0, thisParameter.IndexOf("="));
                        string value = thisParameter.Substring(thisParameter.IndexOf("=") + 1);
                        if (value.Contains("%"))
                        {   //Workaround for VS not expanding variables in debug
                            value = Environment.GetEnvironmentVariable(value.Replace("%", ""));
                        }
