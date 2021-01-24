	public void Awake()
	{
		Action<Cat> action = null;
		action += TestCat;
		action += TestAnimal;
		action += (Action<Cat>) Delegate.CreateDelegate( typeof( Action<Cat> ), this, "TestCat2" );
		action += new Action<Cat>
        ( 
            (Action<Cat>) Delegate.CreateDelegate( typeof( Action<Animal> ), this, "TestAnimal2" )
        );
		// Test
		action.Invoke( new Cat() );
	}
