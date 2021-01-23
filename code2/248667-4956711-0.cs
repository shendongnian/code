    [TestFixture]
        public class Class1
        {
            private DateTime _now;
    
            [SetUp]
            public void SetUp()
            {
                _now = DateTime.MinValue.AddDays(1).AddHours(2); //02.01.0001 02:00:00
            }
    
            [Test]
            public void TestCase()
            {
                Assert.IsTrue(IsDoTime(20, 30, 3, 30));
            }
    
            bool IsDoTime(int starthour, int startminute, int endhour, int endminute)
            {
                var start1 = DateTime.MinValue.AddHours(starthour).AddMinutes(startminute); //01.01.0001 20:30:00
    
                var end1 = endhour < starthour
                               ? DateTime.MinValue.AddDays(1).AddHours(endhour).AddMinutes(endminute) //02.01.0001 03:30:00
                               : DateTime.MinValue.AddHours(endhour).AddMinutes(endminute);
    
                return ((_now > start1) && (_now < end1));
            }
        }
