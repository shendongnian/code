    public class NoFocusRadioButton: RadioButton
    {
        // ---> If you DO NOT want to allow focus to the control, and want to get rid of
        // the default focus rectangle around the control, use the following ...
        // ... constructor
        public NoFocusRadioButton()
        {
            // ... removes the focus rectangle surrounding active/focused radio buttons
           this.SetStyle(ControlStyles.Selectable, false);
        }
    }
