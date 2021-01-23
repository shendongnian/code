    public class DummyPagerRepo
    {
    	private List<Person> persons;
    	private Person userObject;
    	private int userIndex = -1;
    	
    	public DummyPagerRepo(List<Person> persons, Person userObject)
    	{
    		this.persons = persons;
    		this.userObject = userObject;
    	}
    	
    	public List<Person> GetPage(int pageSize, int pageOffset)
    	{
    		List<Person> results = new List<Person>(pageSize);
    		int start = pageOffset * pageSize;
    		if(pageOffset == 0)
    		{
    			result.add(userObject);
    			start++;
    		}
    		int end = Math.Min(persons.length, pageSize * (pageOffset + 1));
    		for(int i = start; i < end; i++)
    		{
    			Person person = persons[i];
    			if(userIndex == -1 && person.ID == userObject.ID)
    			{
    				userIndex = i;
    			}
    			else if(userIndex != i)
    			{
    				resutls.Add(person);
    			}
    		}
    		
    		if(userIndex != -1 && start <= userIndex && end > userIndex && end < persons.length)
    		{
    			results.add(persons[end]);
    		}
    		return results;
    	}
    }
