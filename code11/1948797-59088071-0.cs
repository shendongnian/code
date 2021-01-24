    void Main()
    {
    	//Input:
    	//Tom Jones 07722990000 1
    	//Katy Perry 01122334455 1
    	//Kylie Jenner 01267483233 2
    	//Taylor Swift 1234543234 3
    	//Rod Stewart 07722996700 2
    	//Liam Payne 07722995000 3
    	//Harry Styles 07722994000 1
    	//Jonas Blue 07722993000 1
    	//Rita Ora 07722290000 1
    	//Tom Walker 07722990010 1
    
    
    	string fileName = @"C:\\TEMP\\London.txt";
    	string outputFileName = @"C:\\TEMP\\output.txt";
    	List<Participant> list = GetParticipants(fileName);
    	CreateOutput(list, outputFileName);
    
    	//	Total Registered Participants: 10
    	//	Registered Participants for Slot 1: 6
    	//	Registered Participants for Slot 2: 2
    	//	Registered Participants for Slot 3: 2
    	//	Participant 1 Name: Tom Jones
    	//	Participant 2 Name: Katy Perry
    	//	Participant 3 Name: Kylie Jenner
    	//	Participant 4 Name: Taylor Swift
    	//	Participant 5 Name: Rod Stewart
    	//	Participant 6 Name: Liam Payne
    	//	Participant 7 Name: Harry Styles
    	//	Participant 8 Name: Jonas Blue
    	//	Participant 9 Name: Rita Ora
    	//	Participant 10 Name: Tom Walker
    }
    
    private void CreateOutput(List<Participant> list, string outputFileName)
    {
    	using(StreamWriter w = new StreamWriter(outputFileName))
    	{
    		w.WriteLine($"Total Registered Participants: {list.Count}");
    		w.WriteLine($"Registered Participants for Slot 1: {list.Count(x => x.Slot == 1)}");
    		w.WriteLine($"Registered Participants for Slot 2: {list.Count(x => x.Slot == 2)}");
    		w.WriteLine($"Registered Participants for Slot 3: {list.Count(x => x.Slot == 3)}");
    		
		    int i=1;
		    foreach(Participant p in list)
		    {
			    w.WriteLine($"Participant {i} Name: {p.Name}");
			    i++;
		    }
    	}
    }
    
    private List<Participant> GetParticipants(string fileName)
    {
    	List<Participant> list = new List<UserQuery.Participant>();
    	if(File.Exists(fileName))
    	{
    		string pattern = @"(.*?)([\d]+)\s+([\d]+)";
    		int outValue;
    		using(StreamReader reader = new StreamReader(fileName))
    		{
    			while(reader.Peek() != -1)
    			{
    				string line = reader.ReadLine();
    				Match m = Regex.Match(line, pattern);
    				if(m.Success && m.Groups.Count > 2)
    				{
    					Participant p = new Participant();
    					p.Name = m.Groups[1].Value;
    					p.Phone = m.Groups[2].Value;
    					if(int.TryParse(m.Groups[3].Value, out outValue))
    						p.Slot = outValue;
    					list.Add(p);
    				}
    			}
    		}
    	}
    	return list;
    }
    
    public class Participant
    {
    	public string Name {get;set;}
    	public string Phone {get;set;}
    	public int Slot {get;set;}
    }
