    interface IJsonLinqParser<TEntity>
        where TEntity : System.Data.Objects.DataClasses.EntityObject
    {
        Expression<Func<TEntity, bool>> CreateCriteriaExpression(string myCriteria);
        Expression<Func<TEntity, bool>> CreateCriteriaExpressionForCustomProperties(string myCriteria)
    }
