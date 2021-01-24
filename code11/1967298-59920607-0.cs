    string acName = "";
    string acValue = "";
    bool foundit = false;
    Word.AutoCorrectEntries ACs = wdApp.AutoCorrect.Entries;
    foreach (Word.AutoCorrectEntry AC in ACs)
    {
        acName = AC.Name;
        acValue = AC.Value;
        Debug.Print("Name: {0}, Value: {1}", acName, acValue);
        if (acName == "CU")
        {
            foundit = true;
            break;
        }
    }
    if (foundit)
    {
        MessageBox.Show("Found it: " + acValue);
    }
    else MessageBox.Show("Not present");
