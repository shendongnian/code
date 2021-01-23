        var textboxes = Panel1.Controls.OfType<TextBox>();
        foreach (TextBox txt in textboxes)
        {
            string fieldname = txt.ID.Remove(0, 3); //"txtDescription" becomes "Description"
            string value = equipment.GetType().GetProperty(fieldname).GetValue(equipment, null) as string;
            txt.Text = value;
        }
