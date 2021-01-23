    using System.IO;
    using System.Collections.Generic;
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                var reader = File.OpenText(@"c:\input.txt");
                var list = new List<string>();
            
                while(true)
                {
                    var line = reader.ReadLine();
                    if (line == null) break;
                    list.Add(line);
                }
            
                list = HandleRemoveTRequirement(list);
                list = HandleFourDigitRequirement(list);
                list = HandleConcatRequirement(list);
                list = HandleStartsWithBRequirement(list);
                list = HandleSecondElementIsBRequirement(list);
            }
            static List<string> HandleSecondElementIsBRequirement(List<string> list)
            {
                var result = new List<string>();
                foreach (var line in list)
                {
                    var parts = line.Split(' ');
                    if (parts[1].Equals("B"))
                    {
                        parts[0] += "A";
                        parts[1] = string.Empty;
                        result.Add(string.Join(" ", parts));
                    }
                    else
                    {
                        result.Add(line);
                    }
                }
                return result;
            }
            static List<string> HandleStartsWithBRequirement(List<string> list)
            {
                var result = new List<string>();
                var i = 0;
            
                foreach (var line in list)
                {
                    var parts = line.Split(' ');
                
                    if (parts[0].Equals("B"))
                    {
                        parts[0] = string.Empty;
                        result.Add(list[i - 1].Split(' ')[0] + "A" + string.Join(" ", parts));
                    }
                    else
                    {
                        result.Add(line);
                    }
                    i++;
                }
                return result;
            }
        
            static List<string> HandleConcatRequirement(List<string> list)
            {
                var result = new List<string>();
                foreach (var line in list)
                {
                    var parts = line.Split(' ');
                    int test;
                    if (int.TryParse(parts[0], out test) || parts[0].Equals("B"))
                    {
                        result.Add(line);
                    }
                    else
                    {
                        result[result.Count -1] += line;
                    }
                }
                return result;
            }
            static List<string> HandleRemoveTRequirement(List<string> list)
            {
                var result = new List<string>();
                foreach (var line in list)
                {
                    var parts = line.Split(' ');
                    if (parts[1].Equals("T"))
                    {
                        parts[1] = string.Empty;
                    }
                    result.Add(string.Join(" ", parts).Replace("  ", " "));
                }
                return result;
            }
            static List<string> HandleFourDigitRequirement(List<string> list)
            {
                var result = new List<string>();
                foreach (var line in list)
                {
                    var parts = line.Split(' ');
                    int test;
                    if (int.TryParse(parts[0], out test))
                    {
                        parts[0] = parts[0].PadLeft(4, '0');
                        result.Add(string.Join(" ", parts));
                    }
                    else
                    {
                        result.Add(line);
                    }
                }
                return result;
            }
        }
    }
