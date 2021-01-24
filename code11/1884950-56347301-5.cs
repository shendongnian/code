     if (_inputProfile.GetPrimaryFireButton() || 
    _inputProfile.GetSecondaryFireButton())
    {
        if (!_target.HasValue) _target = GetObjectClosestToAim();
        if (_inputProfile.GetPrimaryFireButton())
        {
            OnPrimaryFire.Invoke(_target.Value);
        }
        if (_inputProfile.GetSecondaryFireButton())
        {
            OnSecondaryFire.Invoke(_target.Value);
        }
    }
 
