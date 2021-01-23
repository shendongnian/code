    public class YourTestClass
    {
        [TestMethod]
        public void CreateNewsLetter_Should_Return_Empty_NewsLetter()
        {
            var template = new Template
            {
                PlaceHolders = new List<TemplatePlaceholder>()
            };
            var newsLetter = new NewsLetter { Template = template };
            const string content = "<html><body><!--BROWSER--></body></html>";
            INewsletterService service = new BuildNewsLetterStub(content);
            string actual = service.CreateNewsLetter(newsLetter);
            
            Assert.AreEqual(content, actual);
        }
    }
    public class BuildNewsLetterStub : NewsLetterService
    {
        private string _letter;
        public BuildNewsLetterStub(string letter)
        {
            _letter = letter;
        }
        public override string BuildNewsLetterHTML(NewsLetter newsLetter)
        {
            return _letter;
        }
    }
