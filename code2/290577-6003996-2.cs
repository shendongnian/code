    public static void DelphiNetConsole()
    {
        System.IsConsole = true;
        try
        {
            TextOutput.Output.WriteWideString("Hello From Delphi 2007.Net", 0).WriteLn();
            System.@_IOTest();
        }
        catch (Exception exception1)
        {
            Exception exception2 = System.@ExceptObject = exception1;
            Exception E = exception1;
            TextOutput.Output.WriteWideString(TObjectHelper.ClassName(System.@GetMetaFromObject(E)), 0).WriteWideString(": ", 0).WriteWideString(E.Message, 0).WriteLn();
            System.@_IOTest();
            System.@ExceptObject = null;
        }
    }
 
