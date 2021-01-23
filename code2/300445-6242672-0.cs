    .
    .
    .
    if (txtID.Text.Length > 0)
    {
        long id;
        if (Int64.TryParse(txtID.Text, out id))
        {
            filter = "ID = " + id.ToString();
        }
    }
    .
    .
    .
