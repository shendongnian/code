    btnImportar.Click += delegate
     {
      UserDialogs.Instance.ShowLoading("Aguarde...", MaskType.Black);
      Task.Run(()=> {
           string stm = "DELETE FROM Trender";
           using (SqliteCommand cmd2 = new SqliteCommand(stm, con))
             {
              cmd2.ExecuteNonQuery();
             }
          });
 
     }
