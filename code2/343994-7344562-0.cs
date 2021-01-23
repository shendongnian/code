        MockRepository mocks = new MockRepository();
        IServiceCalls serviceCallsMock = MockRepository.GenerateMock<IServiceCalls>();
        _controller.ServiceCalls = serviceCallsMock;
        serviceCallsMock.Expect(x => x.GetX(2)).Return(new List<X> { new X{ Id = 1 } });
        serviceCallsMock.GetX(2).Return;
        _controller.Index();
        serviceCallsMock.VerifyAllExpectations()
