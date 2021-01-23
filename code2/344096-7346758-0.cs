    StringBuilder sb = new StringBuilder();
    foreach (string s in Dettaglio)
    {
        sb.Append(s + Environment.NewLine);
    }
    txtDettaglio.Text = sb.ToString();
