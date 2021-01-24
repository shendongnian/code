    class Place
    {
        public virtual void Visit()
    	{
    		// What happens during visit,
    		// if the derived class doesn't override the Visit method
    	}
    }
    
    class Toilet : Place
    {
    	public override void Visit()
    	{
    		// Visit functionality specific to the Toilet Place
    	}
    }
