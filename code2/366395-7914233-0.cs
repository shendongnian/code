    private bool _askedToCancel;
    
    private void LongRunning()
    {
        foreach (string comment in theInternets)
        {
            if (!_askedToCancel)
            {
                Troll(comment);
            }
            else
            {
                break;
            }
        }
    }
