    ClassBD.DBMyInsertCommand("INSERT INTO Albuns " +
                    "(NArtista, NEditora, NGeneroDeMusica, NMedia, Nome, [Ano de Edição]) " +
                    "VALUES (" + temptabelas[0] + "," + temptabelas[1] + "," + temptabelas[2] + "," + temptabelas[3] + ",'" + TxtAddMusicaAlbum.Text + "'," + int.Parse(TxtAddAnoEdicao.Text) + ")");
                OleDbConnection connection = new OleDbConnection(ClassBD.MyConnectionString);
                connection.Open();
                OleDbCommand MyCommand = new OleDbCommand("SELECT NAlbum FROM Albuns WHERE (Nome = @Nome)", connection);
                MyCommand.Parameters.AddWithValue("@Nome", TxtAddMusicaAlbum.Text);
                OleDbDataReader myReader = MyCommand.ExecuteReader(CommandBehavior.CloseConnection);
                ClassBD.tempnalbum = myReader.GetInt32 ;
