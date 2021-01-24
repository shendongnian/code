     public bool CanExecute(object parameter)
        {
            MainWindowViewModel viewModel = parameter as MainWindowViewModel;
            if (viewModel.isNeedToCheck && viewModel.IsWholeModelSet)
                return false;
            return true;
        }
