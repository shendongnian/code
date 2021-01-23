        public static class Math
        {
            [Microsoft.SqlServer.Server.SqlFunction]
            public static int Add(int a, int b)
            {
                return a + b;
            }
            [Microsoft.SqlServer.Server.SqlProcedure]
            public static void Void(int a, int b)
            {
            }
        }
