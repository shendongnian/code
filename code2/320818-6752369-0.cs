    public class ComponentLocation
            {
                public string ReferenceDesignator { get; set; }
    
                public string PartNumber { get; set; }
    
                public double xValue { get; set; }
    
                public double yValue { get; set; }
    
                public int Rotation { get; set; }
    
                public string Package { get; set; }
    
            }
    
            public IEnumerable<ComponentLocation> ParseColumns(string fileName)
            {
                IEnumerable<string> rawData = File.ReadLines(fileName);
                var rows = rawData.Skip(1).Select(l => l.Split('\t')).Select(str => new ComponentLocation
                                                                            {
                                                                                ReferenceDesignator = str[0],
                                                                                PartNumber = str[1],
                                                                                xValue = double.Parse(str[2]),
                                                                                yValue = double.Parse(str[3]),
                                                                                Rotation = int.Parse(str[4]),
                                                                                Package = str[5]
                                                                            });
                return rows;
            }
    
            public void DoWork(double x, double y, string fileName)
            {
                var components = ParseColumns(fileName);
                //Add values
                foreach (var component in components)
                {
                    component.xValue += x;
                    component.yValue += y;
                }
    
                //build file
                StringBuilder sbData = new StringBuilder();
                //header
                sbData.AppendLine("R.D.\tP.N.\tX\tY\tRot\tPkg");
                //data
                foreach (var component in components)
                {
                    sbData.Append(component.ReferenceDesignator).Append('\t');
                    sbData.Append(component.PartNumber).Append('\t');
                    sbData.AppendFormat("{0:###.###}", component.xValue).Append('\t');
                    sbData.AppendFormat("{0:###.###}", component.yValue).Append('\t');
                    sbData.Append(component.Rotation).Append('\t');
                    sbData.Append(component.Package).Append('\t').AppendLine();
                }
                //write
                File.WriteAllText(fileName, sbData.ToString());
             
            }
    
            //call DoWork
            DoWork(10.552, -140.123, @"C:\myfile.txt")
