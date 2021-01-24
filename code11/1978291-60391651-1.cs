      private void TB_PLAYERNAME_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                TC_GAME.SelectedIndex = 5;
                string Avh = TB_PLAYERNAME.Text;
                StreamWriter wr = new StreamWriter("PlayerName.txt", true);
                wr.WriteLine(Avh + "," + totalScore);
                wr.Flush();
                wr.Close();
                TB_PLAYERNAME.Text = "";
            }
            
        }
 
      
