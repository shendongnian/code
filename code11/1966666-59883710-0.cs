c#
mockRepository
  .Setup(m => m.AllSearchBy(It.IsAny<Expression<Func<Rate_End_HSB_SLC, bool>>[]>()))
  .Returns(predicates => predicates
    .Aggregate(
      rateEndHsbSlcTable, 
      (source, predicate) => source.Where(predicate.Compile())).AsQueryable());
