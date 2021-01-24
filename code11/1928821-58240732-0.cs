        using (TextFieldParser parser = new TextFieldParser(@"<path to testcsv.csv>"))
                    {
                        parser.TextFieldType = FieldType.Delimited; 
                        parser.SetDelimiters(",", "|");
                        string[] current = parser.ReadFields();
                        string[] formats = new string[] { "yyyy-MM-dd", "dd/MM/yyyy", "MM/dd/yyyy" };
                        foreach (string f in current)
                        {
                            DateTime dv ;
                            if (DateTime.TryParseExact(f, formats, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dv))
                            {
                                Console.WriteLine($"found date - { dv.ToLongDateString()}");
                            }
                            else 
                            {
                                Console.WriteLine($"found something  - {f}");
                            }
                        }
                    }
