    protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            char c = Convert.ToChar(e.Text);
            if (Char.IsNumber(c))
                e.Handled = false;
            else
                e.Handled = true;
                        
            base.OnPreviewTextInput(e);
        }
