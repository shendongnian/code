     {
                if (startDate < periodStartDate)
                {
                    if (endDate>=periodStartDate)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }                             
                }
                else
                {
                    if (startDate <= periodEndDate)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
