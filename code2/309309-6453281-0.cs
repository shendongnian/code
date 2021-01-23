       [Test]      
        public void IsApplesOrBannans() 
        {      
           bool IsApple = true;     
           bool IsBannana = false;    
           if (!(IsApple || IsBannana))   
                Assert.Fail();        
           Assert.Pass();       
        }
