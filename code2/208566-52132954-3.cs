    string results = "";
    StringBuilder sb = new StringBuilder();
    string longest = "Department:  ";
    foreach (EncounterInfo enc in lei)
    {
        results += enc.Description + " " + enc.ResultValue + " " + enc.ResultUnits + "\r\t";
    }
    results = results.TrimEnd(new char[] { '\r', '\t' });
    results = results.Replace("\t", StringLengthFormat("  ", longest));
    sb.AppendLine(StringLengthFormat("Result(s):  ", longest) + results);
    sb.AppendLine(StringLengthFormat("Patient:  ", longest) + ei.PatientName);
    sb.AppendLine(StringLengthFormat("Accession:  ", longest) + ei.AccessionNumber);
    sb.AppendLine(longest + ei.CollectionClassDept);
    sb.AppendLine();
    sb.AppendLine("Continue?");
    dr = MessageBox.Show(sb.ToString(), "Add to Encounters", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
