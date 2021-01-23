var MyQry=(from P5 in table.AsEnumerable() select P5["id"]).Distinct().ToList();
for (int O1 = 0; O1 < MyQry.Count; O1++)
{
     richTextBox1.Text = MyQry[O1].ToString();
}
