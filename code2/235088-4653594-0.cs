    public virtual Stream BaseStream
    {
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get
        {
            return this.stream;
        }
    }
