       if (reader.Read())
                {
                    account = new Account();
                    account.Id = reader.GetInt32(0);
                    account.Name = reader.GetString(1);
                    account.MailVerifiedAt = GetNullable(reader, 2, reader.GetDateTime);
                    account.MailToken = GetNullable(reader, 3, reader.GetString);
                }
