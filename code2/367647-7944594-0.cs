    public static string GetSqlExceptionMessage(int number)
    {
      //set default value which is the generic exception message
      string error = MyConfiguration.Texts.GetString(ExceptionKeys.DalExceptionOccured);   
      switch (number)
      {
        case 4060:
          // Invalid Database
          error = MyConfiguration.Texts.GetString(ExceptionKeys.DalFailedToConnectToTheDB);   
        break;
        case 18456:
          // Login Failed
          error = MyConfiguration.Texts.GetString(ExceptionKeys.DalFailedToLogin);   
        break;
        case 547:
          // ForeignKey Violation
          error = MyConfiguration.Texts.GetString(ExceptionKeys.DalFKViolation);   
        break;
        case 2627:
          // Unique Index/Constriant Violation
          error = MyConfiguration.Texts.GetString(ExceptionKeys.DalUniqueConstraintViolation);
        break;
        case 2601:
          // Unique Index/Constriant Violation
          error =MyConfiguration.Texts.GetString(ExceptionKeys.DalUniqueConstraintViolation);   
        break;
        default:
          // throw a general DAL Exception
          MyConfiguration.Texts.GetString(ExceptionKeys.DalExceptionOccured);   
        break;
      }
    
      return error;
    }
