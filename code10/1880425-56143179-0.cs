    private void Leave(object sender, EventArgs e){
      _recentTextbox = (TextBox)sender; //_recentTextbox is a class wide TextBox variable
    }
    private void btnA_Click(object sender, EventArgs e)
    {
       if(_recentTextbox == null)
         return;
       _recentTextbox.Select();
       SendKeys.Send("A");
       _recentTextbox = null; //will be set again when a textbox loses focus
    }
