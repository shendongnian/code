    void Main()
    {
	    var input = @"(0010,0010) : Patient's Name                : LANE^LOIS^^^
        (0010,0020) : Patient ID                    : AM-0053
        (0010,0030) : Patient's Birth Date          : 4/15/1982
        (0010,0040) : Patient's Sex                 : F
        (0010,0010) : Patient's Name                : LANE^LOIS^^^
        (0010,0020) : Patient ID                    : AM-0053
        (0010,0030) : Patient's Birth Date          : 4/15/1982
        (0010,0040) : Patient's Sex                 : F
        (0010,0010) : Patient's Name                : LANE^LOIS^^^
        (0010,0020) : Patient ID                    : AM-0053
        (0010,0030) : Patient's Birth Date          : 4/15/1982
        (0010,0040) : Patient's Sex                 : F";
	    List<Patient> patients = new List<Patient>();
	
	    Patient p = null;
	    foreach(var line in input.Split(new[] {'\n'}))
	    {
		    var value = line.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).Last().Trim();
		    if(line.Trim().StartsWith("(0010,0010)"))
		    {
			    if(p != null)
			    	patients.Add(p);
    			p = new Patient();
    			p.Name = value;
    		}
    		else if(line.Trim().StartsWith("(0010,0020)"))
    		{
    			p.ID = value;
    		}
    		else if(line.Trim().StartsWith("(0010,0030)"))
    		{
    			DateTime birthDate;
    			if(DateTime.TryParse(value, out birthDate))
    				p.BirthDate = birthDate;
    		}
    		else if(line.Trim().StartsWith("(0010,0040)"))
    		{
    			p.Sex = value.ToCharArray()[0]; 
    		}
    	}
        if(p != null)
            patients.Add(p);
    }
    public class Patient
    {
	    public string Name { get; set; }
	    public string ID { get; set; }
	    public DateTime? BirthDate { get; set; }
	    public char Sex { get; set; }
    }
