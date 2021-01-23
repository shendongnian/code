    bool GetChecked(object ctrl) {
        bool result = false;
        CheckBox cb = ctrl as CheckBox;
        if ( null == cb ) {
            RadioButton rb = ctrl as RadioButton;
            if ( null == rb ) {
                 throw new Exception ( "ctrl is of the wrong type " );
            }
            result = rb.Checked;
        } else {
            result = cb.Checked;
        }
        return result;
    }
