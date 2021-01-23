                public void Calculate()
            {                
                for(int i = 0; i < 1500; i++)
                {
                    lock (y)
                    {
                        y++;
                    }
                }
            }
