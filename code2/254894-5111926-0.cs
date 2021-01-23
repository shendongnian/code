    public static class DbFactory {
        public static IDbManager CreateDb(DbType type) {
            select (type) {
                case DbType.Sql:
                    return new SqlDbManager();
                    break;
                case DbType.Sql:
                    return new OracleDbManager();
                    break;
            }
        }
    }
