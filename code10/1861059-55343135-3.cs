        [Test]
        public void ResetUsage_ValidateInPlayReset_ReturnsTrue()
        {
            CardSet testDeck = new CardSet();
            testDeck.ResetUsage();
            bool result = true;
            for (int i = 0; i < testDeck.cardArray.Length; i++)
            {
                if (testDeck.cardArray[i].Inplay)
                {
                    result = false; 
                    break;
                }               
            }
            Assert.That(result);
        }
