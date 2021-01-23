    interface IProcessor<in T>  
    {  
        void Process(IEnumerable<T> ts);  
    }
    List<Giraffe> giraffes = new List<Giraffe> { new Giraffe() };  
    List<Whale> whales = new List<Whale> { new Whale() };  
    IProcessor<IAnimal> animalProc = new Processor<IAnimal>();  
    IProcessor<Giraffe> giraffeProcessor = animalProc;  
    IProcessor<Whale> whaleProcessor = animalProc;  
    giraffeProcessor.Process(giraffes);  
    whaleProcessor.Process(whales);  
 
