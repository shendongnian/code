    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    
    namespace TestLogonSid
    {
        public partial class Form1 : Form
        {
    
            private delegate bool EnumDesktopProc(string lpszDesktop, IntPtr lParam);
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click_1(object sender, EventArgs e)
            {
    
                this.textBox1.Text = GetLogonSid.getLogonSid();
            }
    
    
        }
    
        public class GetLogonSid
        {
            //The SID structure that identifies the user that is currently associated with the specified object. 
            //If no user is associated with the object, the value returned in the buffer pointed to by lpnLengthNeeded is zero. 
            //Note that SID is a variable length structure. 
            //You will usually make a call to GetUserObjectInformation to determine the length of the SID before retrieving its value.
            private const int UOI_USER_SID = 4;
            
            //GetUserObjectInformation function
            //Retrieves information about the specified window station or desktop object.
            [DllImport("user32.dll")]
            static extern bool GetUserObjectInformation(IntPtr hObj, int nIndex, [MarshalAs(UnmanagedType.LPArray)] byte[] pvInfo, int nLength, out uint lpnLengthNeeded);
            
    
            //GetThreadDesktop function
            //Retrieves a handle to the desktop assigned to the specified thread.
            [DllImport("user32.dll")]
            private static extern IntPtr GetThreadDesktop(int dwThreadId);
            
    
            //GetCurrentThreadId function
            //Retrieves the thread identifier of the calling thread.
            [DllImport("kernel32.dll")]
            public static extern int GetCurrentThreadId();
            
            //ConvertSidToStringSid function
            //The ConvertSidToStringSid function converts a security identifier (SID) to a string format suitable for display, storage, or transmission.
            //To convert the string-format SID back to a valid, functional SID, call the ConvertStringSidToSid function.
    
            [DllImport("advapi32", CharSet = CharSet.Auto, SetLastError = true)]
            static extern bool ConvertSidToStringSid(
                [MarshalAs(UnmanagedType.LPArray)] byte[] pSID,
                out IntPtr ptrSid);
    
    
            /// <summary>
            /// The getLogonSid function returns the Logon Session string
            /// </summary>
            /// <returns></returns>
            public static string getLogonSid()
            {
                string sidString = "";
                IntPtr hdesk = GetThreadDesktop(GetCurrentThreadId());
                byte[] buf = new byte[100];
                uint lengthNeeded;
                GetUserObjectInformation(hdesk, UOI_USER_SID, buf, 100, out lengthNeeded);
                IntPtr ptrSid;
                if (!ConvertSidToStringSid(buf, out ptrSid))
                    throw new System.ComponentModel.Win32Exception();
                try
                {
                    sidString = Marshal.PtrToStringAuto(ptrSid);
                }
                catch
                {
                }
                return sidString;
            }
        
        }
    }
