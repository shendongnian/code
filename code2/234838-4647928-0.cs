    public static void DoSomething(string str)
    {
        object setting = null;
    
        Try
        {
            setting = CommonSettings.Default[str];
        }
        catch(Exception ex)
        {
            Console.out.write(ex.Message);
        }
    
        if(setting != null)
        {
            DoSomethingElse(setting);
        }
    }
