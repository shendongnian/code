    abstract class AnimalProcessor<T> where T : Animal {
        public abstract IList<T> ProcessResults();
    }
    
    class GiraffeProcessor : AnimalProcessor<Giraffe> {
        public override IList<Giraffe> ProcessResults() {
            return new List<Giraffe>();
        }
    }
    
    class LionProcessor : AnimalProcessor<Lion> {
        public override IList<Lion> ProcessResults() {
            return new List<Lion>();
        }
    }
