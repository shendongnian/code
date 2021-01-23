    var sb = new StringBuilder();
    for (int i = 0; i < checkBoxes.Length; i++)
    {
        if (checkBoxes[i].Checked)
            sb.Append((char)('A' + i));
    }
    var myString = sb.ToString();
