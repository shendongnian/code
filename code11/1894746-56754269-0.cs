    // the unit test. 
    public class UnitTest1 
    {
        Mock<IWaktuSolatServiceApi> waktu;
        /// HERE, remove the parameter
        public UnitTest1()
        {
            this.waktu = new Mock<IWaktuSolatServiceApi>();
        }
        [Fact]
        public async Task ShoudReturn()
        {
            var request = new Solat
            {
                zone = "lala"
            };
            var response = waktu.Setup(x => 
            x.GetAsyncSet()).Returns(Task.FromResult(request));
        }
    }
