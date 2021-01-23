	using System;
	using System.Data;
	using System.Data.SQLite;
	using System.IO;
	using log4net;
	using log4net.Appender;
	using log4net.Config;
	using log4net.Layout;
	namespace ConsoleApplication1
	{
		class SQLiteLogging
		{
			public static void Test()
			{
				BasicConfigurator.Configure(SqLiteAppender.GetSqliteAppender("D:/test.dat"));
				LogManager.GetLogger(typeof (SqLiteAppender)).Info("Hello there");
			}
			public static class SqLiteAppender
			{
				public static IAppender GetSqliteAppender(string dbFilename)
				{
					var dbFile = new FileInfo(dbFilename);
					if (!dbFile.Exists)
					{
						CreateLogDb(dbFile);
					}
	                          
					var appender = new AdoNetAppender
									   {
										   ConnectionType = "System.Data.SQLite.SQLiteConnection, System.Data.SQLite",
										   ConnectionString = String.Format("Data Source={0};Version=3;", dbFilename),
										   CommandText = "INSERT INTO Log (Date, Level, Logger, Message) VALUES (@Date, @Level, @Logger, @Message)"
									   };
					appender.AddParameter(new AdoNetAppenderParameter
											  {
												  ParameterName = "@Date",
												  DbType = DbType.DateTime,
												  Layout = new RawTimeStampLayout()
											  });
					appender.AddParameter(new AdoNetAppenderParameter
											  {
												  ParameterName = "@Level",
												  DbType = DbType.String,
												  Layout = new Layout2RawLayoutAdapter(new PatternLayout("%level"))
											  });
					appender.AddParameter(new AdoNetAppenderParameter
											  {
												  ParameterName = "@Logger",
												  DbType = DbType.String,
												  Layout = new Layout2RawLayoutAdapter(new PatternLayout("%logger"))
											  });
					appender.AddParameter(new AdoNetAppenderParameter
											  {
												  ParameterName = "@Message",
												  DbType = DbType.String,
												  Layout = new RawPropertyLayout { Key = "RenderedMessage" }
											  });
					appender.ActivateOptions();
					return appender;
				}
				public static void CreateLogDb(FileInfo file)
				{
					using (var conn = new SQLiteConnection())
					{
						conn.ConnectionString = string.Format("Data Source={0};New=True;Compress=True;Synchronous=Off", file.FullName);
						conn.Open();
						var cmd = conn.CreateCommand();
						cmd.CommandText =
										 @"CREATE TABLE Log(
								LogId     INTEGER PRIMARY KEY,
								Date      DATETIME NOT NULL,
								Level     VARCHAR(50) NOT NULL,
								Logger    VARCHAR(255) NOT NULL,
								Message   TEXT DEFAULT NULL
							);";
						cmd.ExecuteNonQuery();
						cmd.Dispose();
						conn.Close();
					}
				}
			}
		}
	}
