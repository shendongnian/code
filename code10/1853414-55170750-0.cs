    sut.Setup(x => x.GetAsync(
                    It.IsAny<Expression<Func<TestModel, bool>>>()
                ))
                .Returns((Expression<Func<TestModel, bool>> predict) =>
                {
                    var result = _list.Where(predict.Compile());
                    return Task.FromResult(result);
                });
