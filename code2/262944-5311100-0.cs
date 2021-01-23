    public abstract class AnimalAdapter {
        public abstract DateTime? FeedDate { get; }
        public abstract DateTime? NapTime { get; }
    }
    public class CatAdapter : AnimalAdapter {
        private Cat _cat;
        public CatAdapter(Cat cat) { _cat = cat; }
        public override DateTime? FeedDate { get { return _cat.feedDate; } }
        public override DateTime? NapTime { get { return _cat.napTime; } }
    }
    public class DogAdapter : AnimalAdapter {
        private Dog _dog;
        public DogAdapter(Dog dog) { _dog = dog; }
        public override DateTime? FeedDate { get { return _dog.feedDate; } }
        public override DateTime? NapTime { get { return _dog.napTime; } }
    }
