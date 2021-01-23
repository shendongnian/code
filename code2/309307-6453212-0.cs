    public void IsApplesOrBannans()
    {
        bool IsApple = true;
        bool IsBannana = false;
        if (IsApple || IsBannana)
            Assert.Pass();
        else
            Assert.Fail();            
    }
