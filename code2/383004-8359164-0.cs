        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Ten_Digit_800_Number()
        {
            var myPad = new NumberFormatter();
            Assert.AreEqual<string>("(800) 123-4567", myPad.FormatNumber("18001234567"));
        }
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void Ten_Digit_800_Number()
        {
            var myPad = new NumberFormatter();
            Assert.AreEqual<string>("(800) 123-4567", myPad.FormatNumber("18001234567 "));
        }
        [TestMethod, Owner("ebd"), TestCategory("Proven"), TestCategory("Unit")]
        public void TroubleString()
        {
            var myPad = new NumberFormatter();
            Assert.AreEqual<string>("828464047", myPad.FormatNumber("828464047"));
        }
