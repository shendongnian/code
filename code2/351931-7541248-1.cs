    string[] dic_lines = File.ReadAllLines("path_to_dic_file.dic");
	List<string> l_group1 = new List<string>();
	List<string> l_group2 = new List<string>();
    
    foreach(subjectString in dic_lines)
    {
		Regex regexObj = new Regex(@"(\(.*?\))\s*(.*)\s*");
		Match match = regexObj.Match(subjectString);
		if (matchResults.Success) {
			l_group1.Add(match.Groups[1].Value);
			l_group2.Add(match.Groups[2].Value);
		} 
    }
	File.WritaAllLines("outputfile.txt", l_group1);
	File.AppendAllLines("outputfile.txt", l_group2);
