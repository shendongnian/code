    var validateMemberMock = Mock.Create<Membership.Messages.ValidateMember>();
    Mock.Arrange(() => service.Query<Membership.Messages.ValidateMember>())
                .Returns(validateMemberMock);
    Mock.Arrange(() => validateMemberMock.With(model))
                .Returns(true); 
