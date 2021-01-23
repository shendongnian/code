    private Dictionary<Label,MyObject> _map = new Dictionary<Label,MyObject>();
    ...
    private void Item_Clicked(object sender, system.EventArgs e) 
    { 
         if(sender.GetType() == typeof(System.Windows.Forms.Label)) 
         { 
              System.Windows.Forms.Label label = (System.Windows.Forms.Label)sender;
              MyObject myObject = _map[label];
              myObject.Value = true; 
         } 
    }
