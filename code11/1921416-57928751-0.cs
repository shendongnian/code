cs
using (var stream = new StreamWriter(@"C:\Users\cinim\Unity Projects\QC\TestPics\failedItems.csv"))
{
  foreach(string s in failedItems)
  {
    Debug.Log("writing " + s);
    stream.WriteLine(s);
  }
  stream.Close();
}
