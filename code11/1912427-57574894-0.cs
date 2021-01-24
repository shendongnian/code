    private static async Task<IEnumerable<TReturn>> MultiMapAsync<TReturn>(this IDbConnection cnn, CommandDefinition command, Type[] types, Func<object[], TReturn> map, string splitOn)
            {
                if (types.Length < 1)
                {
                    throw new ArgumentException("you must provide at least one type to deserialize");
                }
    
                object param = command.Parameters;
                var identity = new Identity(command.CommandText, command.CommandType, cnn, types[0], param?.GetType(), types);
                var info = GetCacheInfo(identity, param, command.AddToCache);
                bool wasClosed = cnn.State == ConnectionState.Closed;
                try
                {
                    if (wasClosed) await cnn.TryOpenAsync(command.CancellationToken).ConfigureAwait(false);
                    using (var cmd = command.TrySetupAsyncCommand(cnn, info.ParamReader))
                    using (var reader = await ExecuteReaderWithFlagsFallbackAsync(cmd, wasClosed, CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, command.CancellationToken).ConfigureAwait(false))
                    {
                        var results = MultiMapImpl(null, default(CommandDefinition), types, map, splitOn, reader, identity, true);
                        return command.Buffered ? results.ToList() : results;
                    }
                }
                finally
                {
                    if (wasClosed) cnn.Close();
                }
            }
