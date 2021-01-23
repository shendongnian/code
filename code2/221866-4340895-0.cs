    [TestMethod]
    [HostType("Moles")]
    public void AddDelegateToScanner_ScanHappens_ScanDelegateIsCalled()
    {
        // Arrange
        var scanCalledEvent = new ManualResetEvent(false);
        MCoreDLL.GetTopWindow = () => (new IntPtr(FauxHandle));
    
        // Act
        _scanner.AddDelegateToScanner(_formIdentity, ((evnt) => { scanCalledEvent.Set(); }));
        _scanner.SendScan(new BarcodeScannerEventArgs("12345678910"));
    
        // Wait for event to fire
        bool scanCalledInTime = scanCalledEvent.WaitOne(SOME_TIMEOUT_IN_MILLISECONDS);
    
        // Assert
        Assert.IsTrue(scanCalledInTime);
    }
