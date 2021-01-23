    public interface IParcel {
        int SourceCode { get; set; }
        int DesinationCode { get; set; }
        int Weight { get; set; }
    }
    public class PricingCondition {
        //some conditions that you care about for calculations, maybe the amount of bulk or the date of the sale
        //might possibly be just an enum depending on complexity
    }
    public static class PricingConditions {
        public static readonly PricingCondition FourthOfJulyPricingCondition = new PricingCondition();
        public static readonly PricingCondition BulkOrderPricingCondition = new PricingCondition();
        //these could alternatively come from a database depending on your requirements
    }
    public interface IParcelBasePriceLookupService {
        decimal GetBasePrice(IParcel parcel);
        //probably some sort of caching
    }
    public class ParcelPriceCalculator {
        IParcelBasePriceLookupService _basePriceLookupService;
        decimal CalculatePrice(IParcel parcel, IEnumerable<PricingCondition> pricingConditions = new List<PricingCondition>()) {
            //do some stuff
        }
        decimal CalculatePrice(IEnumerable<IParcel> parcels, IEnumerable<PricingCondition> pricingConditions = new List<PricingCondition>()) {
            //do some stuff, probably a loop calling the first method
        }
    }
