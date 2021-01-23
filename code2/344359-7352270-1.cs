    myLoopingMethod()
    {
        int n = 0;
        for (int i = 0; i < 50;i++)
        {
            n = checkStatus();
            switch (n)
            {
                case 1:
                    return;
            }
        }
    }
