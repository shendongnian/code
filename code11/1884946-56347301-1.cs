     if (_inputProfile.GetPrimaryFireButton() || 
    _inputProfile.GetSecondaryFireButton())
    {
        Ray centerRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0f));
        if (_inputProfile.GetPrimaryFireButton())
        {
            OnPrimaryFire.Invoke(centerRay);
        }
        if (_inputProfile.GetSecondaryFireButton())
        {
            OnSecondaryFire.Invoke(centerRay);
        }
    }
