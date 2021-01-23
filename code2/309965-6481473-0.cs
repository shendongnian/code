    public void ServizioController_PerformAction_Start()
        {
            //Arrange
            Super.Core.Servizio s = new Super.Core.Servizio()
            {
                Action = ServizioAction.START.ToString()
            };
            var mock = new Mock<ServizioController>() { CallBase = true };
            mock.Setup(x => x.Start()).Returns(true);
            mock.Setup(x => x.Stop()).Returns(true);
            mock.Setup(x => x.Continue()).Returns(true);
            //Act
            mock.Object.PerformAction(s);
            //Assert
            mock.Verify(x => x.Start());
            mock.Verify(x => x.Stop());
            mock.Verify(x => x.Continue());
        }
