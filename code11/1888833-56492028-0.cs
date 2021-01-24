    private void NameOfPrivateMethod(object objValue,Hours hours,Item item)
            {
                if (objValue == null)
                {
                    item.Hours = 0;
                }
                else
                {
                    item.Hours = (decimal)objValue;
                    item.Hours_Remaining = (decimal)hours;
                }
            }
