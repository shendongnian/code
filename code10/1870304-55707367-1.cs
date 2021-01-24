    public int SubtractDateToDateFrom(List<Rezerwacje> dateList, DateTime dateTime)
    {
                int count = 0;
                foreach (var item in dateList)
                {
                    if (item.DataDo < dateTime)
                    {
                        count++;
                    }
                }
    
                return count;
    }
