    public class CompanyType: ICompanyType
    {
        public const string HKG = "HKG";
        public const string SHG = "SHG";
        public string Get()
        {
            Random rand = new Random((int) DateTime.UtcNow.Ticks & 0x0000FFFF);
            var flipCoin = rand.Next(0, 1);
            return flipCoin == 0 ? HKG : SHG;
        }
    }
    public interface ICompanyType
    {
        // dummy code, to be replaced with what is needed
        string Get();
    }
