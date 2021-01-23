    class YourItem
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
    }
    
    yourListBox.DisplayMember = "UserName";
    yourListBox.ValueMember = "UserId";
    
    yourListBox.Items.Add(new YourItem {
        UserName = "FooName",
        UserId = "FooId"
    });
