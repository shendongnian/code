    namespace CustomRenderer
    {
    	public class CustomMap : Map
    	{
    		public List<CustomPin> CustomPins { get; set; }
    
            public void doSomething(CustomMap myMap) {
    
                DependencyService.Get<IMapDependencyService>().doSomethingOnMap(myMap);
            }
        }
    
        public interface IMapDependencyService
        {
            void doSomethingOnMap(CustomMap myMap);
        }
    }
