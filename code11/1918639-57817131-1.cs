    DataTable _dtsel = new DataTable("tab1");
    try
    {
        ConOpen();
        using (MySqlCommand cmd = new MySqlCommand(_select, con))
        {
             MySqlDataAdapter _mysel = new MySqlDataAdapter(cmd);
             _mysel.Fill(_dtsel);
             con.close();
        }
    }
    catch (Exception ex) { SendErrorToText(ex); }
    return _dtsel;
