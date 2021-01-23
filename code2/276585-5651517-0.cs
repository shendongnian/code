    Example of first line
    var line = "82 44 b4 2e 39 39 39 39 39 35";
    var bytes = line.Split(' ').Select(b=> Convert.ToByte(Convert.ToInt32(b, 16))).ToArray();
    System.Text.Encoding.ASCII.GetString(bytes); //"?D?.999995"
    int .net 2.0
	string[] line = "82 44 b4 2e 39 39 39 39 39 35".Split(' ');
			
	byte[] bytes = new byte[line.Length];
			
	for (int i = 0; i < line.Length; i++) {
		bytes[i] = Convert.ToByte(Convert.ToInt32(line[i], 16));
	}
			
	string s =  System.Text.Encoding.ASCII.GetString(bytes);
