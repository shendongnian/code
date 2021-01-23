    Public Function GetListviewItem(ByVal hWindow As Long, ByVal pColumn As Long, ByVal pRow As Long) As String
    Dim result              As Long
    Dim myItem              As LV_ITEMA
    Dim pHandle             As Long
    Dim pStrBufferMemory    As Long
    Dim pMyItemMemory       As Long
    Dim strBuffer()         As Byte
    Dim index               As Long
    Dim tmpString           As String
    Dim strLength           As Long
    
    Dim ProcessID As Long, ThreadID As Long
    ThreadID = GetWindowThreadProcessId(hWindow, ProcessID)
    '**********************
    'init the string buffer
    '**********************
    ReDim strBuffer(MAX_LVMSTRING)
    
    '***********************************************************
    'open a handle to the process and allocate the string buffer
    '***********************************************************
    pHandle = OpenProcess(PROCESS_VM_OPERATION Or PROCESS_VM_READ Or PROCESS_VM_WRITE, False, ProcessID)
    pStrBufferMemory = VirtualAllocEx(pHandle, 0, MAX_LVMSTRING, MEM_COMMIT, PAGE_READWRITE)
        
    '************************************************************************************
    'initialize the local LV_ITEM structure
    'The myItem.iSubItem member is set to the index of the column that is being retrieved
    '************************************************************************************
    myItem.mask = LVIF_TEXT
    myItem.iSubItem = pColumn
    myItem.pszText = pStrBufferMemory
    myItem.cchTextMax = MAX_LVMSTRING
    
    '**********************************************************
    'write the structure into the remote process's memory space
    '**********************************************************
    pMyItemMemory = VirtualAllocEx(pHandle, 0, Len(myItem), MEM_COMMIT, PAGE_READWRITE)
    result = WriteProcessMemory(pHandle, pMyItemMemory, myItem, Len(myItem), 0)
    
    '*************************************************************
    'send the get the item message and write back the memory space
    '*************************************************************
    result = SendMessage(hWindow, LVM_GETITEMTEXT, pRow, ByVal pMyItemMemory)
    result = ReadProcessMemory(pHandle, pStrBufferMemory, strBuffer(0), MAX_LVMSTRING, 0)
    result = ReadProcessMemory(pHandle, pMyItemMemory, myItem, Len(myItem), 0)
      
    '**************************************************
    'turn the byte array into a string and send it back
    '**************************************************
    For index = LBound(strBuffer) To UBound(strBuffer)
        If Chr(strBuffer(index)) = vbNullChar Then Exit For
        tmpString = tmpString & Chr(strBuffer(index))
    Next index
    
    tmpString = Trim(tmpString)
    
    '**************************************************
    'deallocate the memory and close the process handle
    '**************************************************
    result = VirtualFreeEx(pHandle, pStrBufferMemory, 0, MEM_RELEASE)
    result = VirtualFreeEx(pHandle, pMyItemMemory, 0, MEM_RELEASE)
    
    result = CloseHandle(pHandle)
    
    If Len(tmpString) > 0 Then GetListviewItem = tmpString
    End Function
