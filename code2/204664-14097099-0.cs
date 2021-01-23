    static IEnumerable<string> GetWords(string path){  
	
        foreach (var line in File.ReadLines(path)){
	        foreach (var word in line.Split(null)){
		        yield return word;
            }
        }
    }
