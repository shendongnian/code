    public List<CheckBox> FindAllCheckBoxControls(WebControl webControl)
    {
         if(webControl.Controls.Count == 0)
             return new List<CheckBox>();
         var checkBoxes = webControl.Controls
              .Where(x => x.GetType() == typeof(CheckBox));
              .Select(x => x as CheckBox)
              .ToList();
         webControl.Controls.ToList().ForEach(control =>
            {
                 checkBoxes.AddRange(FindAllCheckBoxControls(control));
            });
         return checkBoxes.Distinct();
    }
