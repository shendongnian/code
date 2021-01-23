    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Security.Permissions;
    using System.Text;
    using System.Windows.Forms;
    namespace Watcher
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                FileRenamed();           
            }
            private static string _osLanguage = null;
            [PermissionSet(SecurityAction.Demand, Name = "FullTrust")] 
            private void FileRenamed()
            {
                MessageBox.Show("Code is Started Now");
                // Create a new FileSystemWatcher and set its properties.
                FileSystemWatcher watcher = new FileSystemWatcher();
            
                SetDirectoryAccess(@"c:\temp");
            
                watcher.Path = @"C:\Temp";
                /* Watch for changes in LastAccess and LastWrite times, and
                   the renaming of files or directories. */
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                // Only watch text files.
                watcher.Filter = "*.txt";
                // Add event handlers.
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
                watcher.Error += new ErrorEventHandler(OnError);
                // Begin watching.
                watcher.EnableRaisingEvents = true;
            }
            // Define the event handlers.
            private static void OnChanged(object source, FileSystemEventArgs e)
            {
                // Specify what is done when a file is changed, created, or deleted.
                //Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
                MessageBox.Show("Something is changed in the File");
            }
            private static void OnRenamed(object source, RenamedEventArgs e)
            {
                // Specify what is done when a file is renamed.
                MessageBox.Show("File Is Renamed");
                //WatcherChangeTypes wct = e.ChangeType;
                //Console.WriteLine("File {0} {2} to {1}", e.OldFullPath, e.FullPath, wct.ToString());
            }
            //  This method is called when the FileSystemWatcher detects an error.
            private static void OnError(object source, ErrorEventArgs e)
            {
                MessageBox.Show("Error Trapped");
                //  Show that an error has been detected.
                Console.WriteLine("The FileSystemWatcher has detected an error");
                //  Give more information if the error is due to an internal buffer overflow.
                if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
                {
                    //  This can happen if Windows is reporting many file system events quickly 
                    //  and internal buffer of the  FileSystemWatcher is not large enough to handle this
                    //  rate of events. The InternalBufferOverflowException error informs the application
                    //  that some of the file system events are being lost.
                    Console.WriteLine(("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message));
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                //File.Move(@"\\NAS\dossier_echange\Carl\temp\Test.txt", @"\\NAS\dossier_echange\Carl\temp\Test007.txt"); 
                File.Move(@"c:\temp\Test.txt", @"c:\temp\Test007.txt"); 
            }
            internal static void SetDirectoryAccess(string directoryPathString)
            {
                string everyoneString;
                if (OSLanguage.Equals("en-US"))
                    everyoneString = "Everyone";
                else
                    everyoneString = "Tout le monde";
                //sets the directory access permissions for everyone
                DirectorySecurity fileSecurity = Directory.GetAccessControl(directoryPathString);
                //creates the access rule for directory
                fileSecurity.ResetAccessRule(new FileSystemAccessRule(everyoneString, FileSystemRights.FullControl, AccessControlType.Allow));
                //sets the access rules for directory
                Directory.SetAccessControl(directoryPathString, fileSecurity);
            }
            public static string OSLanguage
            {
                get
                {
                    if (_osLanguage == null)
                        _osLanguage = CultureInfo.CurrentCulture.Name;
                    return _osLanguage;
                }
                set
                {
                    _osLanguage = value;
                }
            }
        }
    }
