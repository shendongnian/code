    int groupID = -1;
    string pattern = "(-*-)";
    List<TextBoxBase> controls = new List<TextBoxBase>() { rTBA, rTBB, rTBC };
    string[] input = File.ReadAllLines("[File Path]");
    for (int i = 0; i < input.Length; i++) {
        if (input[i].Contains(pattern)) { 
            groupID += 1; 
            continue; 
        }
        if (groupID == controls.Count) break;
        controls[groupID].AppendText(input[i] + Environment.NewLine);
    }
