    [TestMethod]
    public void TestMethod_Scenario_Result()
    {
        var stubs = new IFool[5];
        for (int i = 0; i < stubs.Length; ++i)
        {
            var fool = MockRepository.GenerateStub<IFool>();
            fool.Stub(x => x.AmIFool).Return(false);
            stubs[i] = fool;
        }
        foreach (var stub in stubs)
            new Fool(stub);
    }
