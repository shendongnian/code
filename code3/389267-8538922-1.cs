    public static class DogFactory
    {
    	public static Dog CreateMysteryDog()
    	{
    		return new Shitzu();
    	}
    }
    	
    Dog dog = DogFactory.CreateMysteryDog(); // what is the concrete type of Dog?  
