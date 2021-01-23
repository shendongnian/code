    Public class EngineFilterEventArgs : EventArgs
    {
        Public int Id {get; set;}
        Public EngineFilterEventArgs(int id)
        {
            Id = id;
        }
    }
