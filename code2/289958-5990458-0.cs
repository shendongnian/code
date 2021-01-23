    string testString = "Hello";
    UTF8Encoding encoding = new UTF8Encoding();
    byte[] buf = encoding.GetBytes(testString);
    
    StringBuilder binaryStringBuilder = new StringBuilder();
    foreach (byte b in buf)
    {
    	binaryStringBuilder.Append(Convert.ToString(b, 2));
    }
    Console.WriteLine(binaryStringBuilder.ToString());
