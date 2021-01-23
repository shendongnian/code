	byte[] bytes = new byte[line.Length];
			
	for (int i = 0; i < line.Length; i++) {
      int candidate = Convert.ToInt32(line[i], 16);
      if (!(!(candidate < 0x20 || candidate > 127)))
        candidate = 46; //.
	  bytes[i] = Convert.ToByte(candidate);
	}
			
	string s =  System.Text.Encoding.ASCII.GetString(bytes);
