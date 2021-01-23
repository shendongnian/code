    DateTime dt; 
    if(DateTime.TryParse(DatetImeValue.Tostring(),dt))   // datetimevalue is your db value
    {
         datetimeproperty = dt;   // in your class declare it as DateTime? datetimeproperty 
    }
    else
    {
        datetimeproperty = null;
    }
