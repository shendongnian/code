    private void panel_MouseClick(object sender, MouseEventArgs e)
    {
        Control ctrl = sender as Control;
        int count = 0;
        //get previous value from control tag
        bool isTagParsed = Int64.TryParse(ctrl.Tag, out count);
        //set backcolor of control based on tag number
             if (count <= 5)  ctrl.BackColor = Color.SlateBlue; 
        else if (count >= 20) ctrl.BackColor = Color.Red;
        else if (count >= 15) ctrl.BackColor = Color.Yellow; 
        else if (count >= 10) ctrl.BackColor = Color.Lime;
        else if (count >= 5)  ctrl.BackColor = Color.Cyan;
        else {// you may want to reset count after a certain number
              // do that here...
              }
        count++; 
        //update control tag with new value
        ctrl.Tag = count + "";
      //switch(ctrl.Id)
      //for individual caller
    }
