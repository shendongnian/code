        [Test]
        public void Test_Extract_First_Row_Mocked()
        {            
            //Arrange
            List<TradeInfo> listExpected = new List<TradeInfo>();
            var tradeInfo = new TradeInfo() { TradeId = "0453", FutureValue = 2000000, PresentValue = 3000000, NotionalValue = 400000 };
            listExpected.Add(tradeInfo);
            var textReader = MockRepository.GenerateMock<TextReader>();
            textReader.Expect(tr => tr.ReadLine()).Return("0453, 2000000, 3000000, 400000");
            var fileParser = new FileParser(textReader);
            var list = fileParser.ProcessFile();           
            listExpected.ShouldAllBeEquivalentTo(list);         
        }
    }
