    DateTime ReturnedDateValue;
    DateTime DateFromSqlDB = EntityClass.DateCreated;
    if (DateTime.TryParse(DateFromSqlDB, ReturnedDateValue))
    {
        /// Do the insert stuff here
    }
