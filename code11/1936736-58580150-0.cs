List<Dictionary<string, object>> bookmarks = new List<Dictionary<string, object>>();
foreach (var barcode in barcodes)
{
Dictionary<string, object> bm = new Dictionary<string, object>();
string title = barcode.Text.Substring(11, barcode.Text.Length - 11);
bm.Add("Title", title);
bm.Add("Action", "GoTo");
bm.Add("Page", barcode.Page.ToString() + " XYZ 0 0 0");
bookmarks.Add(bm);
}
PdfStamper stamp = new PdfStamper(source, output);
stamp.Outlines = bookmarks;
stamp.Close();
