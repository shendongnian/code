    [DllImport("Helper.dll", EntryPoint = "ProcessEvent")]
    private static extern uint ProcessEventExternal(
        [In, Out] ref EventData eventData,
        [In, Out, MarshalAs(UnmanagedType.SysInt))] ref IntPtr resultMessages);
    [DllImport("Helper.dll", EntryPoint = "DeallocateString")]
    private static extern voidDeallocateStringExternal(
        [In, MarshalAs(UnmanagedType.SysInt)] IntPtr arrayPtr);
    [DllImport("Helper.dll", EntryPoint = "ErrorCodeToMessage")]
    private static extern
        [return: MarshalAs(UnmanagedType.SysInt)] IntPtr
        ErrorCodeToMessageExternal(int errorCode);
    public string ProcessEvent(ref EventData eventData)
    {
        IntPtr resultPtr = IntPtr.Zero;
        uint errorCode = ProcessEventExternal(eventData, ref resultPtr);
        if (errorCode != null)
        {
            var errorPtr = ErrorCodeToMessageExternal(errorCode);
            // returns constant string - no need to deallocate
            var errorMessage = Marshal.PtrToStringUni(errorPtr);
            throw new ApplicationException(errorMessage);
        }
        var result = Marshal.PtrToStringUni(resultPtr);
        ExternalDeallocate(resultPtr);
        return result;
    }
