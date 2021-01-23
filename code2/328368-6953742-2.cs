    // keep track of these
    List<Sender> senders;
    int nSelected = 0;          // number of already selected senders
    // ...
    // solution
    int total = senders.Count;  // total number of senders
    // looking for next non-busy sender
    Sender s = null;
    for (int i = 0; i < total; i++)
    {
        int ind = (i + nSelected) % total; // getting the one 'after' previous
        if (!senders[ind].IsBusy)
        {
            s = senders[ind];
            ++nSelected;
            break;
        }
    }
