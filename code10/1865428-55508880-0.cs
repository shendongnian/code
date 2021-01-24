    public class GenericClass<T>
    {
        public  List<T> ReadT(SQLiteCommand command)
        {
            using (IDbConnection cnn = new SQLiteConnection(command.Connection))
            {
                var output = cnn.Query<T>("select * from "+typeof(T).Name, new DynamicParameters());
                return output.ToList();
            }
        }
    }
