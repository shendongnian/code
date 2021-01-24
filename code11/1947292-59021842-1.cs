    using QuantConnect.Data;
    using System.Linq;
    using QuantConnect.Data.Market;
    namespace QuantConnect.Algorithm
    {
        public static class SliceExtensions
        {
            public static FuturesContract GetFuturesContract_ES(this Slice slice, QCAlgorithm Algorithm_ES)
            {
                foreach (var chain in slice.FutureChains)
                {
                    if (chain.Value.Symbol.Value.StartsWith("ES"))
                    {
                        return (from futuresContract in chain.Value.OrderBy(x => x.Expiry)
                                where futuresContract.Expiry > Algorithm_ES.Time.Date.AddDays(1)
                                select futuresContract).FirstOrDefault();
                    }
                }
                return null;
            }
        }
        public class Test
        {
            public void TestMyMethod(Slice slice)
            {
                var contract = slice.GetFuturesContract_ES(new QCAlgorithm());
                //... do something
            }
        }
    }
