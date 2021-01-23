    public interface ICity {
        string Name { get; }
    }
    public abstract class City : ICity
    {
        public sealed T CreateBuilding<T>()
        {
            T buildingInstance = Activator.CreateInstance<T>();
            ((IBuilding)buildingInstance).SetCity(this);
            return buildingInstance;
        }
    }
    public interface IBuilding
    {
        ICity City { get; }
        void SetCity(ICity city);
    }
    public abstract class Building : IBuilding
    {
        private ICity _city;
        public ICity City { get; }
        public sealed void SetCity(ICity city) { 
             this._city = city;
        }
        public abstract string Name { get; }
        public void Print()
        {
            Console.WriteLine(this.Name);
            Console.Write(",");
            Console.WriteLine(this._city.Name);
        }
    }
    public class NewYorkCity : City
    {
        public string Name { get { return "New York"; } }
        EmpEstate empEstate;
        NYTimes nyTimes;
        public void Init()
        {
            // Now I dont need to pass this and no one can create a building in new york 
            // and say I making it for NJ :)
            empEstate = this.CreateBuilding<EmpEstate>();
            setSomeProperty(empEstate);
            // any one can create new object of some other city 
            // and pass to the building
            empEstate = this.CreateBuilding<NYTimes>();
        }
        public void PrintAddresses()
        {
            empEstate.Print();
            nyTimes.Print();
        }
    }
