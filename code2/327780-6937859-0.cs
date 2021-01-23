    private void sendSmsBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
    		StreamReader reader;
    		string[] timeSplit;
    		string[] timeSplit1;
    		string[] titleSplit;
    		string placeholder;
    		string[] categorySplit;
    		
            //For sorted time
            using (reader = new StreamReader(new IsolatedStorageFileStream(fullFolderName + "\\time.Schedule", FileMode.Open, myStore))
    		{
    			placeholder = reader.ReadLine();
    		}
    		timeSplit = placeholder.Split(new char[] { '^' });
    		Array.Sort(timeSplit, delegate(string first, string second)
    		{
               return DateTime.Compare(Convert.ToDateTime(first), Convert.ToDateTime(second)); 
    		}); 
    		
    		using (reader = new StreamReader(new IsolatedStorageFileStream(fullFolderName + "\\time1.Schedule", FileMode.Open, myStore))
    		{
    			placeholder = reader.ReadLine();
    		}
    		timeSplit1 = placeholder.Split(new char[] { '^' });
    		Array.Sort(titleSplit1);
    		
            using (reader = new StreamReader(new IsolatedStorageFileStream(fullFolderName + "\\title.Schedule", FileMode.Open, myStore)))
            {
    			placeholder = reader.ReadLine();
    		}
    		titleSplit = placeholder.Split(new char[] { '^' });
    		Array.Sort(titleSplit);
    		
            using(reader = new StreamReader(new IsolatedStorageFileStream(fullFolderName + "\\category.Schedule", FileMode.Open, myStore)))
    		{
    			placeholder = readFileCategory.ReadLine();
    		}
    
            categorySplit = placeholder.Split(new char[] { '^' });
            Array.Sort(categorySplit);
        }
    
        catch (Exception)
        {
        }
    
        var composeSMS = new SmsComposeTask();
    	var sBuilder = new StringBuilder();
    	sBuilder.AppendLine("Below is my schedule:");
    	
    	for (int i = 0; i < timeSplit.Length; i++)
    	{
    		sBuilder.AppendLine("Date: " + timeSplit[i]);
    		sBuilder.AppendLine("Time: " + titleSplit[i]);
    		sBuilder.AppendLine("End time: " + categorySplit[i]);
    	}
    	
    	composeSMS.Body = sBuilder.ToString();
        composeSMS.Show();
    }
