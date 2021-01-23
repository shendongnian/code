    var checkChanged  = Observable.FromEvent<EventArgs>(this.checkBox, "CheckedChanged");
    var check1Changed = Observable.FromEvent<EventArgs>(this.checkBox1, "CheckedChanged");
    var keyPress      = Observable.FromEvent<KeyPressEventArgs>(this.textBox, "KeyPress");
    
    var plan1 = checkChanged
                .And(check1Changed).And(keyPress)
                .Then((cc, cc1, kp) => "Done.");
    
    var join = Observable.Join(plan1);
    
    join.Subscribe((result) => this.resultTextBox.Text = result);
