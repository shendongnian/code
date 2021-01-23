    private void textTx1Asc_TextChanged(object sender, EventArgs e)
        {
                                
            string s;
           
            //get only the new chars
            s = textTx1Asc.Text;
            s = s.Remove(0, prev_len);          
          
            //update prev_len for next time
            prev_len = textTx1Asc.TextLength;
            //s contains only the new characters, process here
                       
        }
