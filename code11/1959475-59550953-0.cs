protected void btn_Click(object sender, EventArgs e)    
{ 
string[] txt  = File.ReadAllText(Server.MapPath("~/TextFile1.txt"));;
foreach (string line in txt )
{
txtBox1.Text += "\u2022 '" + line + "'\n ";
}
}
