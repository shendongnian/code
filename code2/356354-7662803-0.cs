    public void CreateCheckBox (int max)
    {
        String name = "chkBox_";
        int y = 10;
        for (int i = 0; n < max; i++)
        {
            Checkbox current = new Checkbox();
            current.Location = new Point(10, y);
            current.Name= name + i.ToString();
            form1.Controls.Add(current);
            y+= 15;
        }
    }
