    namespace XsdAutoSpecify
    {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    throw new ArgumentException("Specify a file name");
                }
                string fileName = args[0];
                Regex regex = new Regex(".*private bool (?<fieldName>.*)Specified;");
                IList<string> result = new List<string>();
                IDictionary<string, string> edits = new Dictionary<string, string>();
                foreach (string line in File.ReadLines(fileName))
                {
                    result.Add(line);
                    if (line.Contains("public partial class"))
                    {
                        // Don't pollute other classes which may contain like-named fields
                        edits.Clear();
                    }
                    else if (regex.IsMatch(line))
                    {
                        // We found a "private bool fooSpecified;" line.  Add
                        // an entry to our edit dictionary.
                        string fieldName = regex.Match(line).Groups["fieldName"].Value;
                        string lineToAppend = string.Format("this.{0} = value;", fieldName);
                        string newLine = string.Format("                this.{0}Specified = true;", fieldName);
                        edits[lineToAppend] = newLine;
                    }
                    else if (edits.ContainsKey(line.Trim()))
                    {
                        // Use our edit dictionary to add an autospecifier to the foo setter, as follows:
                        //   set {
                        //       this.fooField = value;
                        //       this.fooFieldSpecified = true;
                        //   }
                        result.Add(edits[line.Trim()]);
                    }
                }
                // Overwrite the result
                File.WriteAllLines(fileName, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Environment.Exit(-1);
            }
        }
    }
    }
