     public async Task<IEnumerable<TResult>> ExecuteReaderAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TResult>(
            TDbConnection connection,
            CommandType cmdType,
            string cmdText,
            TDbParameter commandParameters,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh,TResult> map,
            string splitOn = "Id")
        {
            try
            {
                using (var _connection = connection)
                {
                    _connection.Open();
                    return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TResult>(cmdText, map, commandParameters, splitOn: splitOn, commandType: cmdType);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
