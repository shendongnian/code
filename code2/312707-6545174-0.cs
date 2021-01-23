    public class can_handle_remnant_of_danish_language
    {
        [Fact]
        public void daab_start_with_då()
        {
            var culture = new CultureInfo("da-DK"); Thread.CurrentThread.CurrentCulture = culture;
            Assert.True("daab".StartsWith("då")); // Fails
        }
    
        [Fact]
        public void daab_start_with_da()
        {
            var culture = new CultureInfo("da-DK"); Thread.CurrentThread.CurrentCulture = culture;
            Assert.True("daab".StartsWith("da")); // Fails
        }
    
        [Fact]
        public void daab_start_with_daa()
        {
            var culture = new CultureInfo("da-DK"); Thread.CurrentThread.CurrentCulture = culture;
            Assert.True("daab".StartsWith("daa")); // Succeeds
        }
    
        [Fact]
        public void dåb_start_with_daa()
        {
            var culture = new CultureInfo("da-DK"); Thread.CurrentThread.CurrentCulture = culture;
            Assert.True("dåb".StartsWith("daa")); // Fails
        }
    
        [Fact]
        public void dåb_start_with_da()
        {
            var culture = new CultureInfo("da-DK"); Thread.CurrentThread.CurrentCulture = culture;
            Assert.True("dåb".StartsWith("da")); // Fails
        }
    
        [Fact]
        public void dåb_start_with_då()
        {
            var culture = new CultureInfo("da-DK"); Thread.CurrentThread.CurrentCulture = culture;
            Assert.True("dåb".StartsWith("då")); // Succeeds
        }
    }
