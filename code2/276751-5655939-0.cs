    if(model.Id != null)
    {
        UpdateModel(user);
    }
    else
    {
        _userRepository.Insert(model)
    }
    _userRepository.Save();
