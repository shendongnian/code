    private void Dgm_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        ContentPresenter cp = e.EditingElement as ContentPresenter;
        if (cp != null)
        {
            Panel panel = VisualTreeHelper.GetChild(cp, 0) as Panel;
            if (panel != null)
            {
                TextBox tb = panel.Children.OfType<TextBox>().FirstOrDefault();
                if (tb != null)
                {
                    DateTime dt;
                    if (DateTime.TryParse(tb.Text, out dt))
                    {
                        e.Row.DataContext.GetType().GetProperty("Date").SetValue(e.Row.DataContext, dt);
                    }
                }
            }
        }
    }
