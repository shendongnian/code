    public class AnimalsOwner
    {
        private IList<Animal> _animals;
        public AnimalsOwner()
        {
            _animals = new List<Animal>();
        }
    
        public virtual int Id { get; set; }
        public virtual IEnumerable<Animal> Animals { get { return _animals; } }
    
        public virtual IEnumerable<Cat> Cats { get { return _animals.OfType<Cat>(); } }
    
        public virtual IEnumerable<Dog> Dogs { get { return _animals.OfType<Dog>(); } }
        public virtual void AddAnimal(Animal animal)
        {
            if (!_animals.Contains(animal))
            {
                animal.AnimalsOwner = this;
                _animals.Add(animal); 
            }
        }
        public virtual void RemoveAnimal(Animal animal)
        {
            if (_animals.Contains(animal))
            {
                animal.AnimalsOwner = null;
                _animals.Remove(animal);
            |
         }   
    }
