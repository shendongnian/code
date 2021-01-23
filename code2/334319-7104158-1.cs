    if (user == null)
    {
        _viewModel.PhoneDefault = String.Empty;
    }
    else
    {
        _viewModel.PhoneDefault = user.PhoneDay ?? user.PhoneEvening ?? user.Mobile ?? String.Empty;
    }
