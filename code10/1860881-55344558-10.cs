    _balancerBlock.Completion.ContinueWith(tsk =>
    {
        while (!_typeATickBlock.Completion.IsCompleted)
        {
            if (_printingBuffer.InputCount == 0 && _printingBuffer.OutputCount == 0
            && _typeATickBlock.InputCount == 0 && _typeATickBlock.OutputCount == 0)
            {
                _typeATickBlock.Complete();
            }
        }
    });
