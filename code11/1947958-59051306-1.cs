    //...
    _mediatorMock
        .Setup(s => s.Send<IEnumerable<Product>>(It.IsAny<IRequest<IEnumerable<Product>>>(), It.IsAny<CancellationToken>()))
        .Callback<IRequest<IEnumerable<Product>>, CancellationToken>((query, ct) => 
            ((GetProducts)query).Should().BeEquivalentTo(expectedQuery)
        )
        .ReturnsAsync(Enumerable.Empty<Product>());
    //...
