    var sb = new StringBuilder();
    foreach (var obj in list)
    {
        sb.AppendLine(obj.name);
    }
    MessageBox.Show(sb.ToString(), "Playerlist");
