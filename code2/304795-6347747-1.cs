    [DllImport("ieframe.dll", CharSet = CharSet.Unicode, EntryPoint = "IEGetProtectedModeCookie", SetLastError = true)]
    public static extern int IEGetProtectedModeCookie(String url, String cookieName, StringBuilder cookieData, ref int size, uint flag);
    private void GetCookie_Click(object sender, EventArgs e)
    {
        int iSize = 4096;
        StringBuilder sbValue = new StringBuilder(iSize);
             
        int hResult = IEAPI.IEGetProtectedModeCookie("http://www.google.com", "PREF", sbValue, ref iSize, 0);
    
        if (hResult == 0)
        {
            MessageBox.Show(sbValue.ToString());
        }
        else
        {
            MessageBox.Show("Failed to get cookie. HRESULT=0x" + hResult.ToString("x") + "\nLast Win32Error=" + Marshal.GetLastWin32Error().ToString(), "Failed");
        }
    }
