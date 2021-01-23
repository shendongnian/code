    myStub
        .Stub(_ => _.Create(Arg<Invoice>.Is.Anything))
        .Return(null) // will be ignored but still the API requires it
        .WhenCalled(_ => 
        {
            var invoice = (Invoice)_.Arguments[0];
            invoice.Id = 100;
            _.ReturnValue = invoice;
        );
