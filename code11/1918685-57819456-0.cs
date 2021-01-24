cs
_unitOfWork
    .Setup(x => x.XXXRepository.ListAsync(
        It.IsAny<Expression<Func<XXX, bool>>>(),
        It.IsAny<Expression<Func<XXX, object>>[]>()))
    .ReturnsAsync(XXXs.AsEnumerable());
