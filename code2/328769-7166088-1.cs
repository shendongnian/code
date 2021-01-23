    // Copyright © 2008 Christoph Husse
    using System; 
    using System.Collections.Generic; 
    using System.Runtime.Remoting; 
    using System.Text; 
    using EasyHook;
    namespace FileMon 
    { 
        public class FileMonInterface : MarshalByRefObject 
        { 
            public void IsInstalled(Int32 InClientPID) 
            { 
                Console.WriteLine("FileMon has been installed in target {0}.\r\n", InClientPID); 
            } 
 
            public void OnCreateFile(Int32 InClientPID, String[] InFileNames) 
            { 
                for (int i = 0; i < InFileNames.Length; i++) 
                { 
                    Console.WriteLine(InFileNames[i]); 
                } 
            } 
 
            public void ReportException(Exception InInfo) 
            { 
                Console.WriteLine("The target process has reported an error:\r\n"+ InInfo.ToString()); 
            } 
        } 
 
        class Program 
        { 
            static String ChannelName = null; 
         
            static void Main(string[] args) 
            { 
                try 
                {
                    Config.Register( 
                    "A FileMon like demo application.", 
                    "FileMon.exe", 
                    "FileMonInject.dll"); 
 
                    RemoteHooking.IpcCreateServer<FileMonInterface>(ref ChannelName, WellKnownObjectMode.SingleCall); 
     
                    RemoteHooking.Inject( 
                    Int32.Parse(args[0]), 
                    "FileMonInject.dll", 
                    "FileMonInject.dll", 
                    ChannelName); 
 
                    Console.ReadLine(); 
               } 
               catch (Exception ExtInfo) 
               { 
                    Console.WriteLine("There was an error while connecting to target:\r\n{0}", ExtInfo.ToString()); 
               } 
           } 
        } 
    }
