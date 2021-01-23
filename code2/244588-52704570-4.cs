                builder.UseSqlServer(connection, sql =>
                    {
                        sql.EnableRetryOnFailure();
                        sql.MigrationsAssembly(assembly);
                    })
                    .UseQueryTrackingBehavior(track ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
                    .ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));
