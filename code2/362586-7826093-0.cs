	int a = 34;
	int b = 25;
	int c = 15;
	
	byte[] data = new byte[2];
	
	// Store to byte array
	data[0] = (byte)((a << 2) + (b >> 4));
	data[1] = (byte)((b << 4) + c);
	// Read from byte array
	a = data[0] >> 2;
	b = ((data[0] & 3) << 4) + (data[1] >> 4);
	c = data[1] & 31;
	
	Console.WriteLine("a = " + a); // 34
	Console.WriteLine("b = " + b); // 25
	Console.WriteLine("c = " + c); // 15
