    using (IDriver driver = GraphDatabase.Driver("bolt://localhost:11004", 
        AuthTokens.Basic("neo4j", "Diego123")))
    {
        using (ISession session = driver.Session())
        {
            IStatementResult result = session.Run("CREATE (n:" + nodeLabel + 
                "{name:'" + nodeName + "'})");             
        }
    }
