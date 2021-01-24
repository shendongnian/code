    _mockedDataAccessor
        .Setup(x => x.AuthenticateAsync(It.Is<AuthenticationRequest>(a => a.UserName == "Alice")))
        .ReturnsAsync(...one value...));
    _mockedDataAccessor
        .Setup(x => x.AuthenticateAsync(It.Is<AuthenticationRequest>(a => a.UserName == "Bob")))
        .ReturnsAsync(...something else...));
