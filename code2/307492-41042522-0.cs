			using (var conn = new SqlConnection(GetConnectionStringFromSecret(args)))
			{
				conn.Open();
				stopwatch.Start();
				long counter = 0;
				var tran = conn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
				SqlCommand cmd = new SqlCommand("", conn, tran);
				cmd.CommandType = System.Data.CommandType.Text;
				int batch_param_counter = 0;
				foreach (var chars_table in table_of_table_of_chars)
				{
					var key = string.Concat(chars_table);//get 1st param
					var hash = BitConverter.ToString(hasher.ComputeHash(Encoding.UTF8.GetBytes(key))).Replace("-", "").ToLowerInvariant();//get 2nd param
					cmd.CommandText += $"insert into hash_table([key], hash) values(@key{batch_param_counter}, @hash{batch_param_counter});{Environment.NewLine}";
					var param_key = new SqlParameter("@key" + batch_param_counter, System.Data.SqlDbType.VarChar, 20);
					param_key.Value = key;
					cmd.Parameters.Add(param_key);
					var hash_key = new SqlParameter("@hash" + batch_param_counter, System.Data.SqlDbType.VarChar, 32);
					hash_key.Value = hash;
					cmd.Parameters.Add(hash_key);
					batch_param_counter++;
					if (counter % 200 == 0)
					{
						cmd.Prepare();
						cmd.ExecuteNonQuery();
						cmd.Dispose();
						cmd = new SqlCommand("", conn, tran);
						cmd.CommandType = System.Data.CommandType.Text;
						batch_param_counter = 0;
					}
					if (counter % 20000 == 0)
					{
						if (cmd != null && !string.IsNullOrEmpty(cmd.CommandText))
						{
							cmd.Prepare();
							cmd.ExecuteNonQuery();
							cmd.Dispose();
							cmd = new SqlCommand("", conn, tran);
							cmd.CommandType = System.Data.CommandType.Text;
							batch_param_counter = 0;
						}
						tran.Commit();
						tran = null;
						if (Console.KeyAvailable)
							break;
						cmd.Transaction = tran = conn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
					}
					counter++;
				}
				if (cmd != null && !string.IsNullOrEmpty(cmd.CommandText))
				{
					cmd.Prepare();
					cmd.ExecuteNonQuery();
					cmd.Dispose();
				}
				if (tran != null)
					tran.Commit();
				stopwatch.Stop();
			}
