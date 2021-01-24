private void btnDisplay_Click(object sender, EventArgs e)
{
    listBox1.Items.Clear();
    var files = Directory.EnumerateFiles("C:\\temp\\FOLDER", "*.txt", SearchOption.AllDirectories)
    .Where(s => s.ToUpper().Contains("EUROPE"));
    foreach(string file in files){
        listBox1.Items.Add(file);
    }
}
