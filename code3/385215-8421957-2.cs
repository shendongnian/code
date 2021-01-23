    public KSEDataServIO(IsReadyForUseEventHandler handler)
    {
       IsReadyForUse += handler;
       OnIsReadyForUse(new IsReadyForUseEventArgs("AuthOkay")); // use pattern as described above
    }
    
