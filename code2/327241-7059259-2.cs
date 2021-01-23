    public interface ICity
        {
            string Name { get; }
        }
        public abstract class City : ICity
        {
            public T CreateBuilding<T>()
            {
                T buildingInstance = Activator.CreateInstance<T>();
                ((IBuilding)buildingInstance).SetCity(this);
                return buildingInstance;
            }
    
            public abstract string Name { get; }
        }
    
        interface IBuilding
        {
            ICity City { get; }
            void SetCity(ICity city);
        }
        public abstract class Building : IBuilding
        {
            private ICity _city;
            public ICity City { get { return _city; } }
            public void IBuilding.SetCity(ICity city)
            {
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
        public class EmpEstate : Building
        {
            public override string Name { get { return "Emp State"; } }
        }
        public class NYTimes : Building
        {
            public override string Name { get { return "NY Times"; } }
        }
        public class NewYorkCity : City
        {
            public override string Name { get { return "New York"; } }
    
            EmpEstate empEstate;
            NYTimes nyTimes;
            public void Init()
            {
                // Now I dont need to pass this
                empEstate = this.CreateBuilding<EmpEstate>();
                 setSomeProperty(empEstate);
                // now any one cannot create building in new your and 
                // say it belongs to Philedelphia :)
                nyTimes = this.CreateBuilding<NYTimes>();
            }
    
            public void PrintAddresses()
            {
                empEstate.Print();
                nyTimes.Print();
            }
        }
