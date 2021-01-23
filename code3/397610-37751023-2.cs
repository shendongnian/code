            public static string GetSqlConnection(string connectionStringName = "DefaultConnection")
        {
            // optionally defaults to "DefaultConnection" if no connection string name is inputted
            string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            string passPhrase = "passphrase-used-to-encrypt";
            // decrypt password
            string password = get_prase_after_word(connectionString, "password=", ";");
            connectionString = connectionString.Replace(password, StringCipher.Decrypt(password, passPhrase));
            return connectionString;
        }
