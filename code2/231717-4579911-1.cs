    public void MyMetohd(Somestatus status)
        DoA();
        if (status != SomeStatus.Enum5) {
            DoB();
            if (status != SomeStatus.Enum4) {
                DoC();
                if (status != SomeStatus.Enum3) {
                    DoD();
                    if (status != SomeStatus.Enum2) {
                        DoE();
                    }
                }
            }
        }
    }
