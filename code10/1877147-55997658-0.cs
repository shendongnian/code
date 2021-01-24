     private bool isFileReady(string FilePath)
        {
            try
            {
                if (File.Exists(FilePath))
                    using (File.OpenRead(FilePath))
                    {
                        return true;
                    }
                else
                    return false;
            }
            catch (Exception)
            {
                Thread.Sleep(100);
                return isFileReady(FilePath);
            }
        }
        void FileSystemWatcherCreated(object sender, System.IO.FileSystemEventArgs e)
        {
            if (isFileReady(e.FullPath))
            {
                FileInfo fileInfo = new FileInfo(e.FullPath);
                String letra = e.FullPath.Substring(0, 3);
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                // Creamos una orden con la cadena de texto con la sentencia UPDATE
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = SQLUpdateArchivoCopiado;
                // Añadimos los parámetros Name, Surname y UserId
                command.Parameters.AddWithValue("ArchivoCopiado", e.Name);
                command.Parameters.AddWithValue("Letra", letra);
                // Ejecutamos la sentencia UPDATE y cerramos la conexión
                command.ExecuteNonQuery();
                // SUMAR EL TAMANO DEL ARCHIVO PARA OBTENER EL TOTAL COPIADO
                SQLiteCommand commando = connection.CreateCommand();
                commando.CommandText = SQLSetIncrementTotalCopiado;
                var info = new FileInfo(e.FullPath);
                var theSize = info.Length;
                commando.Parameters.AddWithValue("TotalCopied", theSize);
                commando.Parameters.AddWithValue("Letra", letra);
                // Ejecutamos la sentencia UPDATE y cerramos la conexión
                commando.ExecuteNonQuery();
                connection.Close();
            }
