     for (int I = 0; I < 10 || !something; I++)
            {
                for (int A = 0; A < 10 || !something; A++)
                {
                    for (int B = 0; B < 10; B++)
                    {
                        if (something)
                        {
                           I=10;
                           break;
                        }
                    }
                }
            }
