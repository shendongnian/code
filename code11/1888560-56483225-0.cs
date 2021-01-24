lang-csharp
private Dictionary<string, BindingList<Data>> Dict = new Dictionary<string, BindingList<Data>>();
private void button1_Click(object sender, EventArgs e)
{
   string readText = File.ReadAllText(@"D:\Download\npc_drops.json");
   Dict = JsonConvert.DeserializeObject<Dictionary<string, BindingList<Data>>>(readText);
   foreach (var npc in Dict.Keys)
   {
      listBox1.Items.Add(npc);
   }
}
private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
{
   string curItem = listBox1.SelectedItem.ToString();
   dataGridView1.DataSource = Dict[curItem];
}
//button2_Click remains unchanged.
//button3 is removed from the form.
