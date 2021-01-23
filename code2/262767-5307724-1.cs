    //Here is your code
    System.Diagnostics.Process p = new System.Diagnostics.Process();
    p.StartInfo.FileName = "cmd ";
    p.StartInfo.UseShellExecute = false;
    p.StartInfo.Arguments = "/C net view";
    string input = "\\st1\n,\\st10\n,\\st4\n,\\st5";
    List<string> serverNames = input.Split(',').ToList();
    //Here is the new code where we will clean up the input string 
    //to remove `\\` and `\n`
    List<string> serverNames = new List<string>();
    foreach (var serverName in input.Split(',').ToList())
    {
         serverNames.Add(serverName.Replace("\\","").Replace("\n",""));
    }
    //Continuing with the rest of your code, 
    //but modified the WriteLine to output a coma delimited list
    Console.WriteLine(string.Join(",", serverNames.ToArray()));
    Console.ReadLine();
