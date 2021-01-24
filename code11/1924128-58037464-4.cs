private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
{
       var fmt = File
         .ReadAllLines(excelTemplatePath)
         .Select(line => line.Split(','))
         .GroupBy(arr => arr[0])
         .ToDictionary(gr => gr.Key, gr => gr
         .SelectMany(s => new string[] {s[1], s[2], s[3], s[4], s[5], s[6], s[7] }).ToArray());
        new f2(fmt).Show(); //if you use Show instead of ShowDialog you can have 2 recipes open at the same time
}
//remember to make your form2 constructor take a Dictionary
public Form2(Dictionary<string, string[]> d)
