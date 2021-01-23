    DataView dv = new DataView(DATA_TABLE, "", "ID, Date DESC", DataViewRowState.None);
    for (int i = 1; i < dv.Count; i++)
    {
        if (dv[i - 1].Row["ID"] == dv[i].Row["ID"])
        {
           dv[i].Delete();
           i--;
        }
     }
