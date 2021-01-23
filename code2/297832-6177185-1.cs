    public static IEnumerable<TextBox> GetAllControls(this Control parent)
    {
        foreach (Control control in parent.Controls)
        {
            yield return control;
            foreach(Control descendant in control.GetAllControls())
            {
                yield return descendant;
            }
        }
    }
