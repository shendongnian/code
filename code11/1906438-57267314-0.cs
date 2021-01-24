    _messageBus.Setup(x => x.CreateMessage(It.IsAny<object>()))
        .Returns<object>(obj => 
        {
            var item = new Mock<IMessage>();
            // Setup properties/methods here
            item.Setup(i => i.Id).Returns(obj.Id);
            return item.Object;
        });
