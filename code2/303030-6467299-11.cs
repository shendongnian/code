    public override bool Equals(object obj)
    {
    	if (obj is Person)
    	{
    		Person other = obj as Person;
    		if (other.Firstname == Firstname && other.Surname == Surname)
    		{
    			Debug.WriteLine(string.Format("{0} == {1}", other.ToString(), this.ToString()));
    			return true;
    		}
    		else
    		{
    			Debug.WriteLine(string.Format("{0} <> {1}", other.ToString(), this.ToString()));
    			return false;
    		}
    	}
    	return base.Equals(obj);
    }
 
