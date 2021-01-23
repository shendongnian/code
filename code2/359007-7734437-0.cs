    var row = tableClientTableAdapter1.GetData().
                   Cast<DataRow>()
                   .Where(cName => cName[0].ToString() == txtClientName.Text)
                   .FirstOrDefault(); 
    if (row != null)
    {
         // extract value
    }
