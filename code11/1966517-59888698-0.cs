    public static IGroceryDao BuildGroceryDao(IDbTransaction transaction)
        {
          return (IGroceryDao) new ProxyGenerator()
                                    .CreateInterfaceProxyWithTargetInterface<IGroceryDao>(new Neo4jGroceryDao(transaction), new ExceptionInterceptor());
        }
