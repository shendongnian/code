    public class Place
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
    foreach (var y in Lists)
    {
        listBox1.DisplayMemberPath = "Name";
        listBox1.SelectedValuePath = "Id";
        // Console.WriteLine(y.Case_Number.ToString());
        listBox1.Items.Add(y);
    }
