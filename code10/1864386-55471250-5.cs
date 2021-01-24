    [Test]
    public void Test_Exit_Is_Called
    {
        bool called;
        void fakeExit() { called=true; }
        thatClass.ErrorEncounter(fakeExit);
    
        Assert.True(called);
    }
