    private void panel_MouseClick(object sender, MouseEventArgs e)
    {
        Control ctrl = sender as Control;
        int count = 0;
        //get previous value from control tag
        string tagValue = ctrl.Tag == null ? "0" : ctrl.Tag.ToString();
        bool isTagParsed = Int32.TryParse(tagValue, out count);
        //set backcolor of control based on tag number
             
             if (count >= 20) ctrl.BackColor = Color.Red;
        else if (count >= 15) ctrl.BackColor = Color.Yellow; 
        else if (count >= 10) ctrl.BackColor = Color.Lime;
        else if (count >= 5)  ctrl.BackColor = Color.Cyan;
        else ctrl.BackColor = Color.SlateBlue; 
       // if (count == xx)
        //{// you may want to reset count after a certain number. Do that here...}
        count++; 
        //update control tag with new value
        ctrl.Tag = count + "";
      //switch(ctrl.Id)
      //for individual caller
    }
