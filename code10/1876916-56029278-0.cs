    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                using (DbConnection connection = DbProviderFactory.CreateConnection())
                {
                    connection.ConnectionString = SQLConnectionString;
                    await connection.OpenAsync();
                    DbCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE Users SET Wallpaper=@WallpaperID WHERE DiscordID=@DiscordID";
                    command.Parameters.Add(new SqlParameter("@DiscordID", SqlDbType.BigInt) { Value = UserID });
                    command.Parameters.Add(new SqlParameter("@WallpaperID", SqlDbType.BigInt) { Value = WallpaperID });
                    await command.ExecuteNonQueryAsync();
                    scope.Complete();
                    return true;
                }
            }
