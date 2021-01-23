    [Test]
            public void Test()
            {
                var mockedScannerPort = new Mock<IScannerPort>();
    
                var constructor = typeof(SerialDataReceivedEventArgs).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(SerialData) }, null);
                var eventArgs = (SerialDataReceivedEventArgs)constructor.Invoke(new object[] { SerialData.Eof });
                
                mockedScannerPort.Setup(sp => sp.ReadLine())
                                 .Returns("123")
                                 .Raises(sp => sp.DataReceived += null, new object[] { this, eventArgs });
    
                bool mockEventWasInvoked = false;
                SerialDataReceivedEventArgs ea = null;
                mockedScannerPort.Object.DataReceived += (sedner, e) =>
                                                             {
                                                                 mockEventWasInvoked = true;
                                                                 ea = e;
                                                             };
    
                var retVal = mockedScannerPort.Object.ReadLine();
    
                Assert.AreEqual( "123", retVal );
                Assert.IsTrue(mockEventWasInvoked);
                Assert.IsNotNull( ea );
                Assert.AreEqual( ea.EventType, SerialData.Eof );
            }
