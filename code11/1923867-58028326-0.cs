    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EnvDTE;
    using EnvDTE80;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    using System.Collections;
    
    namespace TwincatCodeGenerator
    {
        [ComImport(),Guid("00000016-0000-0000-C000-000000000046"),InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        interface IOleMessageFilter{
            [PreserveSig]
            int HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo);
            [PreserveSig]
            int RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType);
            [PreserveSig]
            int MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType);
        }
        class MessageFilter : IOleMessageFilter
        {
            public static void Register()
            {
                IOleMessageFilter newFilter = new MessageFilter();
                IOleMessageFilter oldFilter = null;
                int test = CoRegisterMessageFilter(newFilter, out oldFilter);
                if (test != 0)
                {
                    Console.WriteLine(string.Format("CoRegisterMessageFilterfailed with error : {0}", test));
                }
            }
    
            public static void Revoke()
            {
                IOleMessageFilter oldFilter = null;
                int test = CoRegisterMessageFilter(null, out oldFilter);
            }
    
            int IOleMessageFilter.HandleInComingCall(int dwCallType, System.IntPtr hTaskCaller, int dwTickCount, System.IntPtr lpInterfaceInfo)
            {
                //returns the flag SERVERCALL_ISHANDLED.
                Console.WriteLine("HandleIncomingCall");
                return 0;
            }
    
            int IOleMessageFilter.RetryRejectedCall(System.IntPtr hTaskCallee, int dwTickCount, int dwRejectType)
            {
                //Console.WriteLine("RetryRejectedCall");
                // Thread call was refused, try again.
                if (dwRejectType == 2)
                // flag = SERVERCALL_RETRYLATER.
                {
                    // retry thread call at once, if return value >=0 &
                    // <100.
                    return 99;
                }
                return -1;
            }
    
            int IOleMessageFilter.MessagePending(System.IntPtr hTaskCallee, int dwTickCount, int dwPendingType)
            {//return flag PENDINGMSG_WAITDEFPROCESS.
                Console.WriteLine("Message Pending");
                return 2;
            }
    
            [DllImport("Ole32.dll")]private static extern int CoRegisterMessageFilter(IOleMessageFilter newFilter, out IOleMessageFilter oldFilter);
        }
    }
