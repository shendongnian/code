    abstract class AnimalProcessor { 
        public abstract IEnumerable<Animal> ProcessResults(); 
    } 
    class GiraffeProcessor : AnimalProcessor { 
        public override IEnumerable<Animal> ProcessResults() { 
            return new List<Giraffe>(); 
        } 
    } 
     
    class LionProcessor : AnimalProcessor { 
        public override IEnumerable<Animal> ProcessResults() { 
            return new List<Lion>(); 
        } 
    } 
