    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Diagnostics;
    namespace Nop.Plugin.Misc.WebServices.Test
    {
        [TestClass]
        public class TestBase
        {
            [TestMethod]
            public void TestMethod1()
            {
                //See result in TestExplorer - test output 
                var a = new int[]{7,8};
                var b = new int[]{12,23,343,6464,232,75676,213,1232,544,86,97867,43};
                Func<int, int, bool> numberHasDigit = (number, digit) => ( number.ToString().Contains(digit.ToString()) );
                Debug.WriteLine("Unfiltered: All elements of 'b' for each element of 'a'");
                foreach(var l in a.SelectMany(aa => b))
                    Debug.WriteLine(l);
                Debug.WriteLine(string.Empty);
                Debug.WriteLine("Filtered: All elements of 'b' for each element of 'a' filtered by the 'a' element");
                foreach(var l in a.SelectMany(aa => b.Where(bb => numberHasDigit(bb, aa))))
                    Debug.WriteLine(l);
            }
        }
    }
