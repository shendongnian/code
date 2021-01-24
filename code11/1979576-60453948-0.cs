        [TestMethod()]
        public void Test_Mock_Params()
        {
            //Arrange
            var wizard = new Mock<IWizard>();
            var service = new Service(wizard.Object);
            var fireSpell = new FireSpell();
            wizard.Setup(x => x.Cast(It.IsAny<SpellBase>())).Returns(false);
            //Act
            //Assert
            Assert.IsFalse(service.DoSomething(fireSpell));
        }
