    abstract class ShelterBase<T> where T : AnimalBase
    {
        protected List<T> _Animals;
        public AnimalBase() {
           _Animals = CreateAnimalCollection();
        }
     
        protected abstract List<T> CreateAnimalCollection();
        public IEnumerable<AnimalBase> GetAnimals(){return _Animals.Cast<AnimalBase>();}
        //Add remove operations go here
        public void Add(T animal){_Animals.Add(animal);}
        public void Remove(T animal){_Animals.Remove(animal);}
    }
    class Stable : ShelterBase<Horse>
    {
        protected override List<Horse> CreateAnimalCollection(){return new List<Horse>();}
        public IEnumerable<Horse> GetHorses(){return _Animals;}
    }
