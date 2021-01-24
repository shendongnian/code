    public interface ISearchable<T> where T : class
    {
    //..............
    }
    public class LandlordReader : ISearchable<LandlordReader>
    {
        public List<AutocompleteResult> Search(string term)
        {
            ....
        }
    }
    public class CityReader : ISearchable<CityReader>
    {
        public List<AutocompleteResult> Search(string term)
        {
           ....
        }
    }
    public static void RegisterTypes(IUnityContainer container)
    {
            container.RegisterType<ISearchable, CityReader>("City");
            container.RegisterType<ISearchable, LandlordReader>("Landlord");
    }
