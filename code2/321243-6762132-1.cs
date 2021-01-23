    string sDrive = dDrive.ToString();
    try
    {
       string[] sSearch = Directory.GetFiles(sDrive, sFile, SearchOption.AllDirectories);
    }
    catch {}
    foreach(string sResult in sSearch)
    {
        textBox2.Text = sResult + Environment.NewLine;
    }
