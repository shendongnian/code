    [Test]
    public void GetTickCount64_ShouldCall_NativeMethod()
    {
        var nativeMock = MockRepository.GenerateMock<INativeMethods>();            
        var target = GetTarget(nativeMock);
        target.Now();
        nativeMock.AssertWasCalled(_ => _.GetTickCount64());
    }
   
    [Test]
    public void Now_ShouldReturn_Microseconds()
    {
        var expected = Timestamp.FromMicroseconds((long) int.MaxValue * 1000);
        var nativeStub = MockRepository.GenerateStub<INativeMethods>();
        nativeStub.Stub(_ => _.GetTickCount64()).Return(int.MaxValue);
        var target = GetTarget(nativeStub);
        var actual = target.Now();
        Assert.AreEqual(expected, actual);
    }
    
    private static GetTickCount64TimeProvider GetTarget(INativeMethods nativeMock)
    {
        return new GetTickCount64TimeProvider(nativeMock);
    }
