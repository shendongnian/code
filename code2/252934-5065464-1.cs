    bool GetChecked(object ctrl) {
        bool result = false;
        Type reflectedResult = ctrl.GetType();
        PropertyInfo[] properties = reflectedResult.GetProperties();
        List<System.Reflection.PropertyInfo> properties = ctrl.GetProperties ().Where ( itm => itm.Name == "Checked" ).ToList ();
        if ( properties.Count == 1 )
        {
            bool result = (bool)properties[0].GetValue ( ctrl, null );
        } else {
            throw new Exception ( "ctrl is of the wrong type " );            
        }     
        return result;
    }
