    Dictionary<Label, TextBox> m_TextBoxesPairs;
    private void MyForm_Load(object sender, EventArgs e) {
      m_TextBoxesPairs = new Label[] {
        labelFirstName,
        labelSecondName,
        //TODO: put all the relevant labels here
      }
      .ToDictionary(lbl => lbl,
                    lbl => new TextBox() {
                      Parent   = lbl.Parent,
                      Text     = lbl.Text,
                      Location = lbl.Location,
                      Size     = lbl.Size,
                      Visible  = false
                    });
      // If you want to modify Label.Text on TextBox.Text changing
      foreach (var pair in m_TextBoxesPairs)
        pair.Value.TextChanged += (o, ee) => {pair.Key.Text = pair.Value.Text;} 
      EnableEdit(false);  
    }
    private void EnableEdit(bool enabled) {
      foreach (var pair in m_TextBoxesPairs) {
          pair.Key.Visible = !enabled;
          pair.Key.Visible =  enabled;
        } 
    }
