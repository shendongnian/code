    TextBox[] m_TextBoxes;
    private void MyForm_Load(object sender, EventArgs e) {
      m_TextBoxes = new TextBox[] {
        textBoxFirstName, 
        textBoxLastName, 
        //TODO: Put the relevant ones
      };
      // Let all TextBox be in Label mode
      EnableEdit(false);
    }
    private void EnableEdit(bool enabled) {
      foreach (var box in m_TextBoxes)
        if (enabled)
          ToTextBoxMode(box);
        else 
          ToLabelMode(box); 
    }
