    namespace Quant
       {
        public interface IFuturesContractSelector_ES
        {
            void GetFuturesContract_ES(QCAlgorithm Algorithm_ES, Slice slice);
        }
       }
    public class Contract_ES : IFuturesContractSelector_ES
    {
    	private readonly Slice _Slice;
    	private readonly QCAlgorithm _Algorithm_ES;
    	
    	public Contract_ES(QCAlgorithm Algorithm_ES)
                {
    				_Algorithm_ES = Algorithm_ES;
    			}
    	
    	public Contract_ES(Slice slice)
    			{
    				_Slice = slice;
    			}
    			
    public void GetFuturesContract_ES(QCAlgorithm Algorithm_ES, Slice slice)
        {
    	
    	foreach(var chain in slice.FutureChains)
        	{
        		if (chain.Value.Symbol.StartsWith("ES"))
        		{
    				var ES = (from futuresContract in chain.Value.OrderBy(x => x.Expiry)
    				where futuresContract.Expiry > Algorithm_ES.Time.Date.AddDays(1) 
    				select futuresContract).FirstOrDefault();
        		}
        	}
    	return ES;
    	}
    }
