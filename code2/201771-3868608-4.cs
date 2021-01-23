    var checkChanged  = Observable.FromEvent<EventArgs>(this.checkBox, "CheckedChanged");
    var check1Changed = Observable.FromEvent<EventArgs>(this.checkBox1, "CheckedChanged");
    var keyPress      = Observable.FromEvent<KeyPressEventArgs>(this.textBox, "KeyPress");
    var keyPress1     = Observable.FromEvent<KeyPressEventArgs>(this.textBox1, "KeyPress");
    
    var plan1 = checkChanged.And(check1Changed).And(keyPress).Then((cc, cc1, kp) => "Done.");
    var plan2 = keyPress.And(keyPress1).Then((kp, kp1) => "Alternate done.");
    
    var join = Observable.When(plan1, plan2);
