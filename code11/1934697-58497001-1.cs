    btnImportar.Click += delegate
     {
      UserDialogs.Instance.ShowLoading("Aguarde...", MaskType.Black);
      Task.Run(async()=> {
           string stm = "DELETE FROM Trender";
           using (SqliteCommand cmd2 = new SqliteCommand(stm, con))
             {
              await cmd2.ExecuteNonQuery();
             }
          });
 
     }
