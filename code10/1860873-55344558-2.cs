    private void ConfigureBlocks()
    {
        _preparationsBlock.LinkTo(_balancerBlock, _linkOptions);
        _balancerBlock.LinkTo(_typeATickBlock, job => job.Type == Type.A);
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
        _typeATickBlock.LinkTo(_printingBuffer, job => !job.IsCommitable());
        _printingBuffer.LinkTo(_typeATickBlock);
        _typeATickBlock.LinkTo(_writeBlock, _linkOptions, job => job.IsCommitable());            
        _writeBlock.LinkTo(_intermediateCleanupBlock, _linkOptions, job => !job.IsFinished());
        _writeBlock.LinkTo(_finalCleanupBlock, _linkOptions, job => job.IsFinished());
        _intermediateCleanupBlock.LinkTo(_typeATickBlock, _linkOptions, job => job.Type == Type.A);
    }
