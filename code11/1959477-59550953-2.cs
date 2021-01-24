protected void btn_Click(object sender, EventArgs e)    
{ 
string[] txt  = File.ReadAllLines(Server.MapPath("~/TextFile1.txt")); 
foreach (string line in txt )
{
txtBox1.Text += "\u2022 '" + line + "'\t\n";
}
}
