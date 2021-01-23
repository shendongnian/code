    string tag = "";
    string op = "";
    string val_rep = "";
    string war = "";
    
    if (DicomFile.IsDicomFile(f))
    {
        Sequence se = plik.GetJointDataSets().GetJointSubsequences();
    
        foreach (DataElement el in se)
        {
            if (el.Tag.Element == "0010" && el.Tag.Group == "0020")
            {
                tag = el.Tag.ToString(); //tag group and element
                op = el.VR.Tag.GetDictionaryEntry().Description;//tag description
                val_rep = el.VR.ToString();//value representative
                war = el.Value.ToString();// 
                break;
            }
        }
    }
