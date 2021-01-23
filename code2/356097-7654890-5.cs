    private void Read(State state)
    {
        // The int return value is the amount of bytes read accessible through the Task's Result property.
        Task<int> readTask = Task<int>.Factory.FromAsync(state.NetworkStream.BeginRead, state.NetworkStream.EndRead, state.Data, state.BytesRead, state.Data.Length - state.BytesRead, state, TaskCreationOptions.AttachedToParent);
        readTask.ContinueWith(ReadPacket, TaskContinuationOptions.OnlyOnRanToCompletion);
        readTask.ContinueWith(ReadPacketError, TaskContinuationOptions.OnlyOnFaulted);
    }
