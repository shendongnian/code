    System.Text.StringBuilder sb=new System.Text.StringBuilder();
    
    while (thisreader.Read())
     {
        sb.Append("\n" +  thisreader["id_Client"].ToString() + " " +  
               thisreader["numéro_Teléphone"].ToString());   
       //or
       //sb.Append(string.Format("\n{0} {1}",thisreader["id_Client"],thisreader["numéro_Teléphone"]));      
     }
     MessageBox.Show(sb.ToString());
