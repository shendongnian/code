    bool doContinue = true;
    for (int i = 0; i < 50 && doContinue; i++)
    {
        n = checkStatus();
        switch (n)
        {
            case 1:
                doContinue = false;
        }
    }
