    Public int Value{get;set;}  
    public string Title {get;set;}  
    var item1 = new CustomItem() { Title = "A", Value = 10 };
            var item2 = new CustomItem() { Title = "B", Value = 20 };
            var item3 = new CustomItem() { Title = "C", Value = 30 };
            var lst = new List<CustomItem>();
            lst.Add(item1);
            lst.Add(item2);
            lst.Add(item3);
            comboBox1.DataSource = lst;
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "Value";
