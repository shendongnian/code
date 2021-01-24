    using System;
    using System.Runtime.InteropServices;
    
    namespace WindowsEventLogChecker
    {
      // partial list from "winerror.h"
      public enum ERROR
      {
        ERROR_SUCCESS,
        ERROR_NO_MORE_ITEMS = 259,
        ERROR_EVT_CHANNEL_NOT_FOUND = 15007,
        ERROR_EVT_INVALID_QUERY = 15001
      }
    
      // this is our own enum
      public enum SystemEventType
      {
        Shutdown,
        Abort
      }
    
      // these are from "winevt.h"
      public enum EVT_QUERY_FLAGS
      {
        EvtQueryChannelPath = 0x1,
        EvtQueryFilePath = 0x2,
        EvtQueryForwardDirection = 0x100,
        EvtQueryReverseDirection = 0x200,
        EvtQueryTolerateQueryErrors = 0x1000
      }
    
    
      class Program
      {
        [DllImport("wevtapi.dll", EntryPoint = "EvtQuery", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr EvtQuery(IntPtr session, [MarshalAs(UnmanagedType.LPWStr)] string path, [MarshalAs(UnmanagedType.LPWStr)] string query, int flags);
    
        [DllImport("wevtapi.dll", EntryPoint = "EvtNext", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern bool EvtNext(IntPtr resultSet, int batchSize, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] eventBatch, int timeout, int flags, ref int nReturned);
    
        [DllImport("wevtapi.dll", EntryPoint = "EvtClose", CallingConvention = CallingConvention.StdCall)]
        public static extern bool EvtClose(IntPtr handle);
    
        [DllImport("kernel32.dll", EntryPoint = "GetLastError", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetLastError();
    
        static void Main(string[] args)
        {
          // get the number of scheduled shutdowns in the last hour
          int nShutdowns = GetEventCount(SystemEventType.Shutdown, 3600000);
    
          // get the number of aborted shutdowns in the last hour
          int nAborts = GetEventCount(SystemEventType.Abort, 3600000);
        }
    
        private static int GetEventCount(SystemEventType evtType, int timeSpanMs)
        {
          ERROR status = ERROR.ERROR_SUCCESS;
          IntPtr hResult = IntPtr.Zero;
          IntPtr[] eventBatch = new IntPtr[10];
    
          // these 2 event id's, along with 'USER32' event source, denote requested
          // shutdown and abort, respectively
          string shutDownId = "1074";
          string abortId = "1075";
    
          // XPath query to get the event id, event source, and timespan in ms from now 
          // back to when the event was posted to the event log.
          string format = "*[System[(EventID = {0}) and Provider[@Name=\"USER32\"] and TimeCreated[timediff(@SystemTime) <= {1}]]]";
    
          // The "System" event channel
          string channelPath = "System";
    
          int nEvents = 0;
          int count = 0;
          string evtQuery;
    
          switch (evtType)
          {
            case SystemEventType.Shutdown:
            evtQuery = string.Format(format, shutDownId, timeSpanMs);
            break;
            case SystemEventType.Abort:
            evtQuery = string.Format(format, abortId, timeSpanMs);
            break;
            default:
            throw new InvalidOperationException();
          }
          hResult = EvtQuery(IntPtr.Zero, channelPath, evtQuery, (int)(EVT_QUERY_FLAGS.EvtQueryChannelPath | EVT_QUERY_FLAGS.EvtQueryReverseDirection));
          if (IntPtr.Zero == hResult)
          {
            status = (ERROR)GetLastError();
    
            if (status == ERROR.ERROR_EVT_CHANNEL_NOT_FOUND)
            {
              // log error
              return 0;
            }
            else if (status == ERROR.ERROR_EVT_INVALID_QUERY)
            {
              // log error
              return 0;
            }
            else
            {
              // log error
              return 0;
            }
          }
          while (EvtNext(hResult, 10, eventBatch, 1000, 0, ref nEvents))
          {
            for (int i = 0; i < nEvents; i++)
            {
              count++;
              if (eventBatch[i] != IntPtr.Zero)
              {
                EvtClose(eventBatch[i]);
              }
            }
          }
          status = (ERROR)GetLastError();
          if (status != ERROR.ERROR_NO_MORE_ITEMS)
          {
            // log error here and cleanup any remaining events
            for (int i = 0; i < nEvents; i++)
            {
              if (eventBatch[i] != IntPtr.Zero)
              {
                EvtClose(eventBatch[i]);
              }
            }
          }
          return count;
        }
      }
    }
