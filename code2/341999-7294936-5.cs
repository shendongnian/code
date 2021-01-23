    private void Form1_Load(object sender, EventArgs e)
    {
        //http://www.dreamincode.net/code/snippet1995.htm
        //Declare the string to hold the list:
    
        var keys = new List<RegKey>();
    
        //Snip...
                        
        UserProfileComboBox = UserProfile.Substring(9);
    
        keys.Add(new RegKey {
            Name = UserProfileComboBox,
            KeyPath = skName
        });
        
        //Snip... 
    
        comboBox1.DataSource = keys;
    }
