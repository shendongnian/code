       . . . .
       if (skipRows > 1)
       {
           MessageBox.Show(....);
           return false;
       }
    }
  
    . . . . . .  . .
    try
    {
        if (!CheckValidationByMEAS_TYPE(lotInfo.LotDataTable, MEAS_TYPE, lotInfo)
            return;
    }
    catch (Exception exception)
    {
        . . . . . 
    }
