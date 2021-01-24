    checkoutServiceMock.Setup(c => c.CheckoutSomethings(It.IsAny<CheckOutSomethingsInput>()))
                    .Returns(new List<CheckedOutSomething>
                {
                    new CheckedOutSomething { Id = 10001, Remarks = "Success" },
                    new CheckedOutSomething { Id = 10002, Remarks = "Success" }
                });
    
