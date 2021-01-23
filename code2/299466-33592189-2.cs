        public bool ColseConnexion()
   {
       try
       {
           connexion.Close();
           return true;
       }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
      }
    }   
