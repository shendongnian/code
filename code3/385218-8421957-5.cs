    public KSEDataServIO(IsReadyForUseEventHandler handler)
    {
       IsReadyForUse += handler;
       OnIsReadyForUse(new IsReadyForUseEventArgs("AuthOkay")); // see pattern above
    }
