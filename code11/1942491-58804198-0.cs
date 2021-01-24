    public interface ICatcher
    {
         void MethodThatMakesYouListUseful()
    }
    
    public interface IPerAnimalCatcher<T> : ICatcher where T: Animal
    {
        // different animals can be caught different ways.
        string Catch(T animal);
    }
    
    AnimalCatchers = new List<ICatcher>();
