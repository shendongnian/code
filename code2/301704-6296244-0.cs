    using ClassLibrary1;
    using Microsoft.Moles.Framework;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MoleClassLibrary;
    [assembly: MoledAssembly(typeof(ClassLibrary1.Class1))]
    
    namespace TestProject1
    {
        [TestClass()]
        public class Class1Test
        {
            [TestMethod()]
            [HostType("Moles")]
            public void TestStringTest()
            {
                var target = new Class1();
                var expected = "Mole value.";
                string actual;
                MClass1.AllInstances.TestString = value => expected;
                actual = target.TestString();
                Assert.AreEqual(expected, actual);
            }
        }
    }
