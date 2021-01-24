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
    
        //This is the source file (input)
    	string fileName = @"C:\\TEMP\\London.txt";
        //This is the output file that I want to create
    	string outputFileName = @"C:\\TEMP\\output.txt";
        //I try now to cut the text files in parts and fill in objects
    	List<Participant> list = GetParticipants(fileName);
        //I have now a list of clean object with all information
        //Now I create the output text file with new information
    	CreateOutput(list, outputFileName);
    
        // This is the Output file:
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
    	//I create the new output file here
        using(StreamWriter w = new StreamWriter(outputFileName))
    	{
    		//I know in my collection total of participants, here 10
            w.WriteLine($"Total Registered Participants: {list.Count}");
    		//For each slot I make a linq query, and I have a result for slot 1
            w.WriteLine($"Registered Participants for Slot 1: {list.Count(x => x.Slot == 1)}");
            //same for slot 2
    		w.WriteLine($"Registered Participants for Slot 2: {list.Count(x => x.Slot == 2)}");
            //same for slot 3
    		w.WriteLine($"Registered Participants for Slot 3: {list.Count(x => x.Slot == 3)}");
    		
		    int i=1;
            //for each participant in my collection, I write the name
		    foreach(Participant p in list)
		    {
			    w.WriteLine($"Participant {i} Name: {p.Name}");
			    i++;
		    }
    	}
    }
    
    private List<Participant> GetParticipants(string fileName)
    {
    	//I create an empty collection of object Participant (see class under)
        List<Participant> list = new List<UserQuery.Participant>();
        //I check if the input file exists
    	if(File.Exists(fileName))
    	{
    		//This is the Regex pattern, maybe it's too difficult for you
            //but in clear, I take in each line three part of the text
            string pattern = @"(.*?)([\d]+)\s+([\d]+)";
            //This is used for later to test if the value in the string is an integer
    		int outValue;
            //I open the input file
    		using(StreamReader reader = new StreamReader(fileName))
    		{
    			//I read each line to the end, Peek not consume the reading file
                while(reader.Peek() != -1)
    			{
                    //I read each line
                    string line = reader.ReadLine();
                    //By Regurlar Expression, I take in each line the parts of text
    				Match m = Regex.Match(line, pattern);
                    //I test if the regex is success and if I have more than three parts
    				if(m.Success && m.Groups.Count > 2)
    				{
    					//I create now each Participant object and I fill each part inside
                        Participant p = new Participant();
    					p.Name = m.Groups[1].Value;
    					p.Phone = m.Groups[2].Value;
                        //I test here if we don't have a null value or something other than an integer
    					if(int.TryParse(m.Groups[3].Value, out outValue))
    						p.Slot = outValue;
    					//I add each object in my Collection
                        list.Add(p);
    				}
    			}
    		}
    	}
    	return list;
    }
    
    //This is the class object for Participant
    public class Participant
    {
    	public string Name {get;set;}
    	public string Phone {get;set;}
    	public int Slot {get;set;}
    }
