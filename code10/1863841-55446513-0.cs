csharp
foreach (MailItem mail in publicFolder.Items)
{
  MessageBox.Show(mail.Body, "MailItem body");
  // Split by line, remove dash lines.
  var data = Regex.Split(mail.Body, @"\r?\n|\r")
    .Where(l => !l.StartsWith('-'))
    .ToList();
  // Remove headers
  for(var i = data.Count -2; lines >= 0; i -2)
  {
    data.RemoveAt(i);
  }
  // now data contains only the info you want in the order it was presented.
  // Asuming info doesn't have spaces.
  var result = data.SelectMany(d => d.Split(' '));
  // WARNING: Missing info will not be present.
  // {"GR332230", "0000232323", "GX3472", "1", "3411144"}
}
