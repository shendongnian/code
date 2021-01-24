       private void DecryptDumpFile()
        {
            string oldDumpFile = "C:\\backup.sql";
            string newDumpFile = "C:\\backup_new.sql";
            MySqlBackup mb = new MySqlBackup();
            mb.EnableEncryption = true;
            mb.EncryptionKey = "qwerty";
            mb.DecryptSqlDumpFile(oldDumpFile, newDumpFile);
        }
