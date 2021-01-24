        [Test]
        public void ResetUsage_ValidateInPlayReset_ReturnsTrue()
        {
            CardSet testDeck = new CardSet();
            testDeck.ResetUsage();
            bool result = false;
            for (int i = 0; i < testDeck.Size; i++)
            {
                if (!testDeck[i].Inplay)
                    result = true;                
            }
            Assert.That(result == true);
        }
