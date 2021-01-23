    public async Task<Security[]> GetSecurities(IEnumerable<(string code, string exchange)> tickers)
    {
        using (var ctx = await CreateTrEntitiesAsync())
        {
            var securityExpr = Expression.Parameter(typeof(Security), "security");
            Expression expr = null;
            Expression exprToadd;
            foreach (var item in tickers)
            {
                exprToadd = Expression.And(
                    Expression.Equal(Expression.Property(securityExpr, nameof(Security.Code)), Expression.Constant(item.code)),
                    Expression.Or(
                        Expression.Equal(Expression.Property(Expression.Property(securityExpr, nameof(Security.Exchange)), nameof(Exchange.MasterExchangeForStocksId)), Expression.Constant(item.exchange)),
                        Expression.Equal(Expression.Property(securityExpr, nameof(Security.ExchangeId)), Expression.Constant(item.exchange))
                    )
                );
                if (expr == null)
                    expr = exprToadd;
                else
                    expr = Expression.Or(expr, exprToadd);
            }
            var criteria = Expression.Lambda<Func<Security, bool>>(expr, new ParameterExpression[] { securityExpr });
            var items = ctx.Securities.Where(criteria);
            return await items.ToArrayAsync();
        }
    }
