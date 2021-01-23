    Dictionary<PictureBox, CheckBox> association = new Dictionary<PictureBox, CheckBox>();
    			
    // ---------------------------------------
    // then, in your generation code
    
    PictureBox pb = // init
    CheckBox cb = // init
    
    // whatever
    
    association.Add(pb, cb);
    // ---------------------------------------    
    // then, in your click handler for picturebox
    
    PictureBox pb = (PictureBox)sender;
    CheckBox cb = association[pb];
    
    cb.Checked = !cb.Checked;
