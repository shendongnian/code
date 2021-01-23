    public class Parcel
    {
        int SourceCode { get; set; }
        int DestinationCode { get; set; }
        int weight { get; set; }
    }
    public abstract class GeneralCalculator
    {
        //Statics go here, or you can inject them as instance variables
        //and they make sense here, since this is presumably data for price calculation
        protected static ReadOnlyDictionary<int, List<int>> _States_neighboureness;
        protected static ReadOnlyCollection<City> _Citieslist;
        protected static ReadOnlyCollection<Province> _Provinceslist;
        //.... etc
        public abstract Decimal CalculatePrice(Parcel parcel);
    }
    public class ExpressCalculator : GeneralCalculator
    {
        public override decimal CalculatePrice(Parcel parcel)
        {
            return 0.0M;
        }
    }
    public class SpecialCalculator : GeneralCalculator
    {
        public override decimal CalculatePrice(Parcel parcel)
        {
            return 0.0M;
        }
    }
