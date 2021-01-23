    buttonOk.Click += (_,__) =>
    {
      if(txtName.Text.Length == 3)
      {
        errorProvider1.SetError(txtName, "Wrong Length!");
        DialogResult = DialogResult.None;
      }
      else
      {
        errorProvider1.SetError(txtName, string.Empty);
      }
    };
