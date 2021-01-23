    foreach(string target in abc)
    {
      //check this value whether if it exist in the dictionary. if not create a checkbox for it.
      if (!Dictionarycheck.ContainsKey(target))
      {
        CheckBox chk = new CheckBox();
        chk.Text = target;
        SomePanel.Controls.Add(chk);
      }
    }
