    public class ProductionCode
    {
        public void MyMain()
        {
            var myList = new List<string>() {"a", "aa", "aaa"};
    
            var newList = myList.PerfectMatches().AddressMatches(myInputObject).ToList();
        }
    }
    
    public static class test
    {
        public static IEnumerable<string> PerfectMatches(this IEnumerable<string> myList)
        {
            return myList.Where(x => x.EntityScore == 100);
        }
    
    
        public static IEnumerable<string> AddressMatches(this IEnumerable<MyObjectType> myList MyObjectType inputObject)
        {
            return myList.Where(x => x.EntityDetails.Addresses.Any(x => x.Street.Equals(inputObject.Address)
                                                                        && x.StateProvinceDistrict.Equals(inputObject.State)
                                                                        && x.City.Equals(inputObject.City)));
        }
    }
