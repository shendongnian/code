     1   var parent = dvDropShipMsgWrap;             //  parent  child
     2   var child = lblAttributeDropShipMsg;        //  false   false  (initial values)
     3   child.Visible = true;                       //  false   false 
     4   parent.Visible = true;                      //  true    true
     5   parent.Visible = false;                     //  false   false
     6   child.Visible = false;                      //  false   false
     7   parent.Visible = true;                      //  true    false 
