    public interface IFood
    {
        bool IsTasty { get; }
    }
    public class Hamburger : IFood
    {
        public bool IsTasty {get{ return true;}}
    }
    public class PeaSoup : IFood
    {
        public bool IsTasty { get { return false; } }
    }
    public class FoodFactory
    {
        private Dictionary<string, Type> _foundFoodTypes =
            new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        /// Scan all specified assemblies after food.
        /// </summary>
        public void ScanForFood(params Assembly[] assemblies)
        {
            var foodType = typeof (IFood);
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (!foodType.IsAssignableFrom(type) || foodType.IsAbstract || foodType.IsInterface)
                        continue;
                    _foundFoodTypes.Add(type.Name, type);
                }
            }
            
        }
        /// <summary>
        /// Create some food!
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IFood Create(string name)
        {
            Type type;
            if (!_foundFoodTypes.TryGetValue(name, out type))
                throw new ArgumentException("Failed to find food named '" + name + "'.");
            return (IFood)Activator.CreateInstance(type);
        }
    }
