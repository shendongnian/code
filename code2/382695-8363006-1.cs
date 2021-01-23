    public class NoFocusRadioButton: RadioButton
    {
        // ---> If you DO want to allow focus to the control, and want to get rid of the
        // default focus rectangle around the control, use the following ...
        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }
    }
