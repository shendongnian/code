    foreach (string key in param.Keys)
    {
        rs.Write(boundaryBytes, 0, boundaryBytes.Length);
        string formitem = string.Format(formdataTemplate, key, param[key]);
        byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
        rs.Write(formitembytes, 0, formitembytes.Length);
    }
    rs.Write(boundaryBytes, 0, boundaryBytes.Length);
    rs.Close();
