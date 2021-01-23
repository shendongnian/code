       int count = 0;
        var mock = MockRepository.GenerateStub<ICell>();
        mock.Stub(p => p.Value).WhenCalled(a => a.ReturnValue = count).Return(42);
        mock.Stub(p => p.IncrementValue()).WhenCalled(a => {
            count = (int)count+1; 
        });
