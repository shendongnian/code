    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>(new[] { 1, 2, 3, 4 });
            
            MakeItNull(list);
            Contract.Assert(list != null);
            
            MakeItRealNull(ref list);
            Contract.Assert(list == null);
        }
       
        static void MakeItNull(List<int> list)
        {
            list = null;
        }
        static void MakeItRealNull(ref List<int> list)
        {
            list = null;
        }
    } 
