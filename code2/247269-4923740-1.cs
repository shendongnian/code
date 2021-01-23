    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Diagnostics;
    namespace TFDestroyDeleted
    {
      class Program
      {
        static void Main(string[] args)
        {
          if (args.Length < 1 || args.Length > 3)
            Usage();
          bool prepareOnly = false;
          bool previewOnly = false;
          if (args.Any(s => StringComparer.InvariantCultureIgnoreCase
              .Compare(s, "preview") == 0)) previewOnly = true;
          if (args.Any(s => StringComparer.InvariantCultureIgnoreCase
              .Compare(s, "norun") == 0)) prepareOnly = true;
          string tfOutput = null;
          Process p = new Process();
          p.StartInfo = new ProcessStartInfo("tf")
          {
            Arguments = string.Format
              ("dir /recursive /deleted \"{0}\"", args[0]),
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            RedirectStandardInput = true
          };
          p.Start();
          tfOutput = p.StandardOutput.ReadToEnd();
          p.WaitForExit();
          string basePath = null;
          string nextDelete = null;
          List<string> toDelete = new List<string>();
          using (var ms = 
            new MemoryStream(Encoding.Default.GetBytes(tfOutput)))
          {
            using (StreamReader sr = new StreamReader(ms))
            {
              while (!sr.EndOfStream)
              {
                nextDelete = null;
                string line = sr.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                  basePath = null;
                else
                {
                  if (basePath == null)
                  {
                    if (line.EndsWith(":"))
                      basePath = line.Substring(0, line.Length - 1);
                    else
                      continue;
                  }
                  else
                  {
                    nextDelete = Regex.Match(line, @"^.*?;X[0-9]+").Value;
                    if (!string.IsNullOrWhiteSpace(nextDelete))
                    {
                      toDelete.Add(
                        string.Format
                        ( 
                          "{0}/{1}", basePath, 
                          nextDelete.StartsWith("$") ? nextDelete.Substring(1) 
                          : nextDelete
                        ));
                    }
                  }
                }
              }
            }
          }
          using (var fs = File.OpenWrite("destroy.tfc"))
          {
            fs.SetLength(0);
            using (var sw = new StreamWriter(fs))
            {
              //do the longest items first, naturally deleting items before their
              //parent folders
              foreach (var s in toDelete.OrderByDescending(s => s.Length))
              {
                if (!previewOnly)
                  sw.WriteLine("destroy \"{0}\" /i", s);
                else
                  sw.WriteLine("destroy \"{0}\" /i /preview", s);
              }
              sw.Flush();
            }
          }
          if (!prepareOnly)
          {
            p.StartInfo = new ProcessStartInfo("tf")
              {
                Arguments = string.Format("@{0}", "destroy.tfc"),
                UseShellExecute = false
              };
            p.Start();
            p.WaitForExit();
          }
          p.Close();
        }
        static void Usage()
        {
          Console.WriteLine(@"Usage:
    TFDestroyDeleted [TFFolder] (preview) (norun)
    Where [TFFolder] is the TFS root folder to be purged - it should be quoted if there are spaces.  E.g: ""$/folder/subfolder"".
    norun - Specify this if you only want a command file prepared for tf.
    preview - Specify this if you want each destroy to be only a preview (i.e. when run, it won't actually do the destroy) ");
          Environment.Exit(0);
        }
      }
    }
