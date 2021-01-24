    using NSubstitute;
    using Xunit;
    public delegate bool GetDataHandler(string name, ref byte[] data);
    public interface ISomeType {
        event GetDataHandler OnGetData;
    }
    public class SampleFixture {
        string lastNameUsed = "";
        byte[] lastBytesUsed = new byte[0];
        [Fact]
        public void SomeTest() {
            var sub = Substitute.For<ISomeType>();
            var data = new byte[] { 0x42 };           
            sub.OnGetData += Sub_OnGetData;
            sub.OnGetData += Raise.Event<GetDataHandler>("name", data);
            Assert.Equal("name", lastNameUsed);
            Assert.Equal(data, lastBytesUsed);
        }
        private bool Sub_OnGetData(string name, ref byte[] data) {
            lastNameUsed = name;
            lastBytesUsed = data;
            return true;
        }
    }
