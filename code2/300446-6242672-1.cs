    .
    .
    .
    if (txtID.Text.Length > 0)
    {
        int id;
        if (Int32.TryParse(txtID.Text, out id))
        {
            filter = "ID = " + id.ToString();
        }
    }
    .
    .
    .
