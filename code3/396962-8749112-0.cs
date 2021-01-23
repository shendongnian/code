    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics.Contracts;
    
    namespace ContractModulo
    {
    	class Program
    	{
    		UInt32 Pick()
    		{
    			return 0;
    		}
    
    		public int Next(int max)
    		{
    			Contract.Requires<ArgumentOutOfRangeException>(0 <= max && max <= int.MaxValue);
    			Contract.Ensures(0 <= Contract.Result<int>());
    			Contract.Ensures(Contract.Result<int>() < max);
    
    			return (int)(Pick() % max);
    		}
    
    		static void Main(string[] args)
    		{
    		}
    	}
    }
