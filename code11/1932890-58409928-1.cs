    private void MarkAsSafeToStop()
    {
        if(!yourClass.IsBackgroundProcessActive)
        {
            throw new OperationCancelledException();
        }
    }
