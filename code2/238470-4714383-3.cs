    	public void GenerateCodes()
    	{
    		Random random = new Random();
    		DateTime timeValue = DateTime.MinValue;
    	    // Create 10 codes just to see the random generation.
    		for(int i=0; i<10; ++i)
    		{
    			int rand = random.Next(3600)+1; // add one to avoid 0 result.
    			timeValue = timeValue.AddMinutes(rand);
    			byte[] b = System.BitConverter.GetBytes(timeValue.Ticks);
    			string voucherCode = Transcoder.Base32Encode(b);
                Console.WriteLine(string.Format("{0}-{1}-{2}", 
                                  voucherCode.Substring(0,4),
                                  voucherCode.Substring(4,4),
                                  voucherCode.Substring(8,5)));
    		}
    	}
