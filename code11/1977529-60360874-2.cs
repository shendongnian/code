    _mockedDataAccessor
        .Setup(x => x.AuthenticateAsync(It.Is<AuthenticationRequest>(a => a.Username == "Alice")))
        .ReturnsAsync(...one value...));
    _mockedDataAccessor
        .Setup(x => x.AuthenticateAsync(It.Is<AuthenticationRequest>(a => a.Username == "Bob")))
        .ReturnsAsync(...something else...));
