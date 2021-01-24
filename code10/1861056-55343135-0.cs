        [Test]
        public void ResetUsage_ValidateInPlayReset_ReturnsTrue()
        {
            CardSet testdeck = new CardSet();
            testdeck.ResetUsage();
            bool result = false;
            for (int i = 0; i < testdeck.cardArray.Length; i++)
            {
                if (testdeck.cardArray[i].Inplay == false)
                {
                    result = true;
                }
            }
            Assert.That(result = true);
        }
