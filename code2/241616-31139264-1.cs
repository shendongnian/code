    [TestFixture]
    public class IpComparerTest : AbstractUnitTest
    {
        private IpComparer _testee;
        [SetUp]
        public void Setup()
        {
            _testee = new IpComparer();
        }
        [TestCase("10.156.35.205", "10.156.35.205")]
        [TestCase("0.0.0.1", "0.0.0.1")]
        [TestCase("2001:0db8:0000:08d3:0000:8a2e:0070:7344", "2001:db8:0:8d3:0:8a2e:70:7344")]
        [TestCase("2001:0db8:0:0:0:0:1428:57ab", "2001:db8::1428:57ab")]
        [TestCase("2001:0db8:0:0:8d3:0:0:0", "2001:db8:0:0:8d3::")]
        [TestCase("::ffff:127.0.0.1", "::ffff:7f00:1")]
        public void Compare_WhenIpsAreEqual_ThenResultIsZero(string ip1, string ip2)
        {
            // Arrange
            IPAddress x = IPAddress.Parse(ip1);
            IPAddress y = IPAddress.Parse(ip2);
            // Act and Assert
            Assert.That(_testee.Compare(x, y), Is.EqualTo(0));
        }
        [TestCase("10.156.35.2", "10.156.35.205")]
        [TestCase("0.0.0.0", "0.0.0.1")]
        [TestCase("1001:0db8:85a3:08d3:1319:8a2e:0370:7344", "2001:0db8:85a3:08d3:1319:8a2e:0370:7344")]
        [TestCase("2001:0db8:85a3:08d3:1319:8a2e:0370:7343", "2001:0db8:85a3:08d3:1319:8a2e:0370:7344")]
        public void Compare_WhenIp1IsLessThanIp2_ThenResultIsLessThanZero(string ip1, string ip2)
        {
            // Arrange
            IPAddress x = IPAddress.Parse(ip1);
            IPAddress y = IPAddress.Parse(ip2);
            // Act and Assert
            Assert.That(_testee.Compare(x, y), Is.LessThan(0));
        }
        [TestCase("10.156.35.205", "10.156.35.2")]
        [TestCase("0.0.0.1", "0.0.0.0")]
        [TestCase("3001:0db8:85a3:08d3:1319:8a2e:0370:7344", "2001:0db8:85a3:08d3:1319:8a2e:0370:7344")]
        [TestCase("2001:0db8:85a3:08d3:1319:8a2e:0370:7345", "2001:0db8:85a3:08d3:1319:8a2e:0370:7344")]
        public void Compare_WhenIp1IsGreaterThanIp2_ThenResultIsGreaterThanZero(string ip1, string ip2)
        {
            // Arrange
            IPAddress x = IPAddress.Parse(ip1);
            IPAddress y = IPAddress.Parse(ip2);
            // Act and Assert
            Assert.That(_testee.Compare(x, y), Is.GreaterThan(0));
        }
    }
