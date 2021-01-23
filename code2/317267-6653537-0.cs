    ...
    Task validateMarked = Task.Factory.StartNew(() =>
    {
        foreach (AccountContactViewModel viewModel in selectedDataList)
        {
            var localViewModel = viewModel;
            if (localViewModel != null)
            {
                Task validate = Task.Factory.StartNew(
                    () => ValidateAccount(localViewModel),
                    (TaskCreationOptions)TaskContinuationOptions.AttachedToParent);
            }
        }
    });
    ...
