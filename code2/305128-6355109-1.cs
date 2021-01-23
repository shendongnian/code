    public class Person 
    {
      public IList<PersonDetail> PersonDetails;
    }
    	
    public class PersonDetail 
    {
      public bool   Correct;
    }
    	
    void Main()
    {
    	bool[] responses = new bool[] {true, false, true};
    	Person p = new Person();
    	p.PersonDetails = new List<PersonDetail>();
    	p.PersonDetails.Add(new PersonDetail(){Correct = true});
    	p.PersonDetails.Add(new PersonDetail(){Correct = true});
    	p.PersonDetails.Add(new PersonDetail(){Correct = false});
    	
    	//bool allGood = p.PersonDetails.Select((pd, index) => pd.Correct == responses[index]).All(x => x==true);
        bool allGood = responses.SequenceEqual(p.PersonDetails.Select(x => x.Correct));
    	allGood.Dump(); // LINQpad extension
    }
