    byte[] bytes = (byte[])dt.Rows[0]["LNL_BLOB"];
    System.Text.StringBuilder foto=new System.Text.StringBuilder();
    foreach (byte b in bytes)
    {
       foto.AppendFormat(",{0}",b);
    }
    return foto.ToString(); /* Or however you're using your string now */
