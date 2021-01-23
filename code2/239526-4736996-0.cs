    public class DogService
    {
        public List<Dog> GetAllDogs()
        {
            var r = new Repository(); // Your data repository
            return r.Dogs.ToList();   // assuming your repository exposes a 'Dogs query'
        }
    }
