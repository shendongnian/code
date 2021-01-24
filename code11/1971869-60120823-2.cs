    public class ProductionCode
    {
        public void MyMain()
        {
            var myList = new List<EntityThingType>() { .... };
    
            var newList = myList.PerfectMatches().AddressMatches(myInputObject).ToList();
        }
    }
    
    public static class test
    {
        public static IEnumerable<EntityThingType> PerfectMatches(this IEnumerable<EntityThingType> myList)
        {
            return myList.Where(x => x.EntityScore == 100);
        }
    
    
        public static IEnumerable<EntityThingType> AddressMatches(this IEnumerable<EntityThingType> myList, MyObjectType inputObject)
        {
            return myList.Where(x => x.EntityDetails.Addresses.Any(x => x.Street.Equals(inputObject.Address)
                                                                        && x.StateProvinceDistrict.Equals(inputObject.State)
                                                                        && x.City.Equals(inputObject.City)));
        }
    }
