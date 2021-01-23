    public class TestClass
    {
        public bool Test1 { get; set; }
        public bool Test2 { get; set; }
        public bool Test3 { get; set; }
    }
    void Test(Control parent, TestClass tc)
    {
        int y = 10;
     
        foreach (var prop in tc.GetType().GetProperties())
        {
            var cb = new CheckBox(); 
            cb.Name = prop.Name;   
            cb.Text = prop.Name;
            cb.DataBindings.Add(new Binding("Checked", tc, prop.Name));
            cb.Location = new Point(10, y);
            parent.Controls.Add(cb);
            y += 25;
        }
    }
