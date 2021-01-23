    class ContextManager
    {
        [ThreadStatic]
        public static ArticleEntities CurrentContext;
    }
