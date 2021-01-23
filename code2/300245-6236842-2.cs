    private bool SaveTextViewState
    {
        get
            {
                if (this.TextMode == TextBoxMode.Password) return false;
            }
            if (((base.Events[EventTextChanged] == null) && 
                  base.IsEnabled) && 
                  ((this.Visible && !this.ReadOnly)  && 
                  (base.GetType() == typeof(TextBox))))
            {
                return false;
            }
            return true;
        }
    }
