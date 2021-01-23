    /// <summary>
    /// Retrieves the IBaseFilter with the requested name
    /// </summary>
    /// <param name="deviceName">The friendly name of the device to retrieve</param>
    /// <param name="deviceType">The type of device to retrieve</param>
    /// <returns>Returns the filter with the given friendly name, or null if no such filter exists</returns>
    public static IBaseFilter GetDeviceFilterByName(string deviceName, EncoderDeviceType deviceType)
    {
        int hr = 0;
        IEnumMoniker classEnum = null;
        IMoniker[] moniker = new IMoniker[1];
        // Create the system device enumerator
        ICreateDevEnum devEnum = (ICreateDevEnum)new CreateDevEnum();
        // Create an enumerator for the video or audio capture devices
        if (deviceType == EncoderDeviceType.Audio)
        {
            hr = devEnum.CreateClassEnumerator(FilterCategory.AudioInputDevice, out classEnum, 0);
        } else
        {
            hr = devEnum.CreateClassEnumerator(FilterCategory.VideoInputDevice, out classEnum, 0);
        }
        
        DsError.ThrowExceptionForHR(hr);
        Marshal.ReleaseComObject(devEnum);
        // no enumerators for video/audio input devices
        if (classEnum == null)
        {
            return null;
        }
        IBaseFilter foundFilter = null;
        // enumerate all input devices, looking for one with the desired friendly name
        while(classEnum.Next(moniker.Length, moniker, IntPtr.Zero) == 0)
        {
            Guid iid = typeof(IPropertyBag).GUID;
            object props;
            moniker[0].BindToStorage(null, null, ref iid, out props);
            object currentName;
            (props as IPropertyBag).Read("FriendlyName", out currentName, null);
            if ((string)currentName == deviceName)
            {
                object filter;
                iid = typeof(IBaseFilter).GUID;
                moniker[0].BindToObject(null, null, ref iid, out filter);
                foundFilter = (IBaseFilter)filter;
                Marshal.ReleaseComObject(moniker[0]);
                break;
            }
            Marshal.ReleaseComObject(moniker[0]);
        }
        Marshal.ReleaseComObject(classEnum);
        return foundFilter;
    }
    /// <summary>
    /// Opens the property pages for the filter with the given name
    /// </summary>
    /// <param name="filter">The filter for which we wish to retrieve and open the property pages</param>
    public static void ShowDevicePropertyPages(IBaseFilter filter, IntPtr handle)
    {
        // get the ISpecifyPropertyPages for the filter
        ISpecifyPropertyPages pProp = filter as ISpecifyPropertyPages;
        int hr = 0;
        if (pProp == null)
        {
            // if the filter doesn't implement ISpecifyPropertyPages, try displaying IAMVfwCompressDialogs instead
            IAMVfwCompressDialogs compressDialog = filter as IAMVfwCompressDialogs;
            if (compressDialog != null)
            {
                hr = compressDialog.ShowDialog(VfwCompressDialogs.Config, IntPtr.Zero);
                DsError.ThrowExceptionForHR(hr);
            }
            return;
        }
        // get the name of the filter from the FilterInfo struct
        FilterInfo filterInfo;
        hr = filter.QueryFilterInfo(out filterInfo);
        DsError.ThrowExceptionForHR(hr);
        // get the propertypages from the property bag
        DsCAUUID caGUID;
        hr = pProp.GetPages(out caGUID);
        DsError.ThrowExceptionForHR(hr);
        // create and display the OlePropertyFrame
        object[] oDevice = new[] {(object)filter};
        hr = OleCreatePropertyFrame(handle, 0, 0, filterInfo.achName, 1, oDevice,
                                    caGUID.cElems, caGUID.ToGuidArray(), 0, 0, 0);
        DsError.ThrowExceptionForHR(hr);
        // release COM objects
        Marshal.FreeCoTaskMem(caGUID.pElems);
        Marshal.ReleaseComObject(pProp);
        if (filterInfo.pGraph != null)
        {
            Marshal.ReleaseComObject(filterInfo.pGraph);
        }
    }
    [DllImport("oleaut32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
    static extern int OleCreatePropertyFrame(IntPtr hwndOwner,
        int x,
        int y,
        [MarshalAs(UnmanagedType.LPWStr)] string lpszCaption,
        int cObjects,
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4, ArraySubType = UnmanagedType.IUnknown)] object[] lplpUnk,
        int cPages,
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] Guid[] lpPageClsID,
        int lcid,
        int dwReserved,
        int lpvReserved);
