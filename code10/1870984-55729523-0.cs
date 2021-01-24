if(obj.ShowDialog() == DialogResult.OK){
filename = obj.FileName;
textBox1.Text = "";             
StreamReader reader = new StreamReader(filename, true);
while (reader.EndOfStream == false)
{
string newline = reader.ReadLine();
{
string[] values = newline.Split(',');
textBox1.Text = textBox1.Text + values[1] + ", " + values[2] + ": " + values[0] + '"' + values[3] + '"' + " " + '"' + values[4] +'"' + Environment.NewLine;
}
}
reader.Close();
}
