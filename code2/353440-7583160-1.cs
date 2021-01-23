      var mockedScannerPort = new Mock<IScannerPort>();
                
                mockedScannerPort.Setup(sp => sp.ReadLine())
                                 .Returns("123")
                                 .Raises(sp => sp.DataReceived += null, new object[] { this, It.IsAny<SerialDataReceivedEventArgs>() });
    
                bool mockEventWasInvoked = false;
                mockedScannerPort.Object.DataReceived += (sedner, e) => mockEventWasInvoked = true;
                var retVal = mockedScannerPort.Object.ReadLine();
    
                Assert.AreEqual( "123", retVal );
                Assert.IsTrue(mockEventWasInvoked);
