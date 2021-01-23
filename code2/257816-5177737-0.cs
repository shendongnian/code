    if (ArrAcpayee.Length != 1)
    {
        // Create your own more appropriate exception
        throw new SomethingWentWrongException("Expected 1 payee entry; got "
                                              + ArrAcpayee.Length);
    }
    string payee = (string) ArrAcpayee[0];
