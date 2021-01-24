    mock
        .Setup(_ => _.ListAsync(It.IsAny<ISpecification<WindFarm>>()))
        .ReturnsAsync((ISpecification<WindFarm> spec) => {
            //access passed argument
            var criteria = spec.Criteria;
            //use expression to filter a mock list            
            var result = somelist.Where(criteria).OrderBy(spec.OrderBy).ToList();    
            return (IReadOnlyList<WindFarm>)result;
        });
