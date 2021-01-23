    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace UnitTests
    {
        [TestClass]
        public class Tests
        {
            [TestMethod]
            public void Test()
            {
                var conds = new[] { true, false, true };
                var values = conds.Select((c, i) => new Func<object>(() => i)).Where((f, i) => conds[i]);
                var list = values.Select(f => f()).Cast<int>().ToList();
                Assert.AreEqual(list.Count, 2);
            }
        }
    }
