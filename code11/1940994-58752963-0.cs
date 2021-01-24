        public void Work_Conflict()
        {
            //Arrange
            this.Service.Setup(x => x.DoWork()).Throws<SomeException>();
            using (var controller = new MyController()) ;
            //Act
            var result = MyController.Work();
            var badRequest = result as BadRequestObjectResult;
            //Assert
            var conflictCode = 0;
            Assert.AreEqual(conflictCode, badRequest.StatusCode);
            Assert.AreEqual("The message", badRequest.Value);
        }
