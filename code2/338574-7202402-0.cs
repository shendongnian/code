    public static void ShowResponseAndTimeTaken(string firstline)
	{
		try
		{   
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(firstline);
			System.Diagnostics.Stopwatch timer = new Stopwatch();
			timer.Start();
			using (var response = request.GetResponse())
			{
				Console.WriteLine("Response : {0}", response);
			}
			timer.Stop();
			Console.WriteLine("Time taken : {0}", timer.Elapsed); 
		}
		catch(Exception e)
		{
			Console.WriteLine("error : {0}", e.Message);
		}      
	}
