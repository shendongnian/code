        //FORM 1
        Form form1 = new Form();
        Button button1 = new Button();
        Button button2 = new Button();
        button2.Top = button1.Bottom;
        form1.Controls.AddRange(new Control[] { button1, button2 });
        //FORM 2
        Form form2 = new Form();
        RadioButton rb1 = new RadioButton();
        RadioButton rb2 = new RadioButton();
        rb2.Top = rb1.Bottom;
        form2.Controls.AddRange(new Control[] { rb1, rb2 });
        //CLICK EVENT
        button1.Click += (s, e) => { rb1.Invoke(new Action(() => { rb1.Checked = true; })); };
        button2.Click += (s, e) => { rb2.Invoke(new Action(() => { rb2.Checked = true; })); };
        
        //ONE THREAD FOR EACH FORM
        new Thread(new ThreadStart(() => { form1.ShowDialog(); })).Start();
        new Thread(new ThreadStart(() => { form2.ShowDialog(); })).Start();
