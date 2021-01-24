    var PublicDocuments = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
    if (result == DialogResult.Yes)
    {
        subPath = PublicDocuments + @"\"+ token + @"\Tests\";
    }
    else if (result == DialogResult.No)
    {
        subPath = PublicDocuments + @"\Tests\";
    }
