    try {
    	using (FileStream fs = new FileStream(@"c:\abc.txt", FileMode.Open)) {
    		using (StreamReader reader = new StreamReader(fs, Encoding.UTF8)) {
    			string line = null;
    			while ((line = reader.ReadLine()) != null) {
    				Console.WriteLine(line);
    				if (line.Contains("keyword")) {
    
    				}
    				// or using Regex
    				Regex regex = new Regex(@"^pattern$");
    				if (regex.IsMatch(line)) {
    							
    				}
    			}
    		}
    	}
    } catch (Exception ex) {
    	Trace.WriteLine(ex.ToString());
    }
