    panelUserInput.SuspendLayout();
    panelUserInput.Controls.Clear();
    panelUserInput.AutoScroll = false;
    panelUserInput.VerticalScroll.Visible = false;
    // here you'd be adding controls
    int x = 20, y = 20, height = 0;
    for (int inx = 0; inx < numControls; inx++ )
    {
        // this example uses textbox control
        TextBox txt = new TextBox();
        txt.Location = new System.Drawing.Point(x, y);
        // add whatever details you need for this control
        // before adding it to the panel
        panelUserInput.Controls.Add(txt);
        height = y + txt.Height;
        y += 25;
    }
    if (height > panelUserInput.Height)
    {
        VScrollBar bar = new VScrollBar();
        bar.Dock = DockStyle.Right;
        bar.Scroll += (sender, e) => { panelUserInput.VerticalScroll.Value =  bar.Value; };
        bar.Top = 0;
        bar.Left = panelUserInput.Width - bar.Width;
        bar.Height = panelUserInput.Height;
        bar.Visible = true;
        panelUserInput.Controls.Add(bar);
    }
    panelUserInput.ResumeLayout();
    // then update the form
    this.PerformLayout();
