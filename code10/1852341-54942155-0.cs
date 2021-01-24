    protected int isValidUser()
    {
        try
        {
            var returnedValue = Mysql.ExecuteScalar("Support_UserLogin", AppGlobal.UserName, AppGlobal.Password);
            Console.Writeline(returnedValue);//this line is to view what was actually returned.
            return Convert.ToInt32(returnedValue );
        }
        catch (Exception ex)
        {
            AppGlobal.QLog.Enqueue(new clsLogType() { Message = System.Reflection.MethodBase.GetCurrentMethod().Name, ex = ex, logType = LogType.Error });
            return 0 ;
        }
    }
