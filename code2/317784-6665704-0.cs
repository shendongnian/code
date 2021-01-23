    private int CountCheckboxes(Control control)
        {
            CheckBox checkBox = control as CheckBox;
            int count = 0;
            if (checkBox != null)
            {
                if(checkBox.CssClass == "SomeClass")
                    count++;
            }
            foreach (Control child in control.Controls)
            {
                count += CountCheckboxes(child);
            }
            return count;
        }
