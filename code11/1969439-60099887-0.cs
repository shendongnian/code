using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.IO;
using System.Configuration;
namespace SFTP_UploadFiles
{
    class SFTP_Upload_Files
    {
        public static string Server = ConfigurationManager.AppSettings["SFTP_Server"];
        public static int Port = int.Parse(ConfigurationManager.AppSettings["SFTP_Port"]);
        public static string User = ConfigurationManager.AppSettings["SFTP_User"];
        public static string Password = ConfigurationManager.AppSettings["SFTP_Password"];
        public static string local_path = ConfigurationManager.AppSettings["SFTP_PATH_LOCAL"];
        public static void cargar_SFTP(string pathRemoteFile, string pathLocalFile)
        {
            string[] folders = Directory.GetFileSystemEntries(pathLocalFile, "*.", SearchOption.AllDirectories);
            string[] txtfiles = Directory.GetFileSystemEntries(pathLocalFile, "*.txt", SearchOption.AllDirectories);
            string[] entries = Directory.GetFileSystemEntries(pathLocalFile, "*.*", SearchOption.AllDirectories);
            int totalCount_folders= folders.Length;
            int totalCount_entries = entries.Length;
            int totalCount_txtfiles = txtfiles.Length;
            Console.Write("Found #"
                + totalCount_entries +  " elements which #"
                + totalCount_folders + " are directories and #" 
                + totalCount_txtfiles + " are text files.\n" );
            Console.Write("Initializing connection to SFTP\n");
            try
            {
                /* USE THIS IF YOUR SFTP NEEDS THIS SETTINGS */
                /*
                KeyboardInteractiveAuthenticationMethod keybAuth = new KeyboardInteractiveAuthenticationMethod(SFTP_User);
                keybAuth.AuthenticationPrompt += new EventHandler<AuthenticationPromptEventArgs>(HandleKeyEvent);
                ConnectionInfo conInfo = new ConnectionInfo(SFTP_Server, SFTP_Port, SFTP_User, keybAuth);
                */
                using (SftpClient sftp = new SftpClient(Server, Port, User, Password))
                {
                    sftp.Connect();
                    if (sftp.IsConnected)
                    {
                        Console.Write("Console connected to SFTP Server.\n");                  
                        foreach (string folder in folders)
                        {
                            string folderDirectory = Path.GetDirectoryName(folder);
                            folderDirectory = folderDirectory.Replace("C:", "").Replace("local", "").Replace("pathDirectoryNames", "").Replace("\\", "");
                            string folderName = Path.GetFileName(folder);
                            if (String.IsNullOrEmpty(folderDirectory))
                            {
                            }
                            else
                            {
                                folderDirectory = folderDirectory + "/";
                            }
                            if (sftp.Exists("/path/remote/path/" + folderDirectory + folderName))
                            {
                                Console.Write("Directory already exists.\n");
                            }
                            else
                            {
                                string rutaDirectorio = "/remote/path/folder/" + folderDirectory + folderName;
                                string rutaDirectorioProcesados = "/remote/path/folder/directory/" + folderDirectory + folderName;
                                Console.Write("Creating directory in: /remote/path/folder/" + folderDirectory + folderName + "\n");
                                sftp.CreateDirectory(rutaDirectorio);
                            }
                        }
                        foreach (string txtfile in txtfiles)
                        {
                            string txtDirectory = Path.GetDirectoryName(txtfile);
                            string txtDirectoryReal = txtDirectory.Replace(@"C:\local\path", "").Replace("\\","/");
                            string txtName = Path.GetFileName(txtfile);
                            if (String.IsNullOrEmpty(txtDirectoryReal))
                            {                                
                            }
                            else
                            {
                                txtDirectoryReal = txtDirectoryReal + "/";
                            }
                            if (sftp.Exists("/remote/path/toCopyFiles/" + txtDirectoryReal + txtName) && (sftp.Exists("/remote/path/processed/files/" + txtDirectoryReal + txtName)))
                            {
                                Console.Write("File already exists.\n");
                            }
                            else
                            {
                                using (FileStream fileStream = new FileStream(txtfile, FileMode.Open))
                                {
                                    string rutaRemota = "/remote/path/toCopyFiles" + txtDirectoryReal + txtName;
                                    string rutaRemotaProcesados = "/remote/path/processed/files" + txtDirectoryReal + txtName;
                                    sftp.BufferSize = 4 * 1024;
                                    sftp.UploadFile(fileStream, rutaRemota, true, null);
                                    Console.Write("Writing file in : " + rutaRemota + "\n");
                                }
                            }
                        }
                        Console.Write("Files uploaded successfully.\n");
                        Console.Write("Files copy success.\n");
                        Console.Write("Disconnecting console.\n");
                        sftp.Disconnect();
                    }
                    else
                    {
                        Console.Write("Error, can't connect to the server.\n");
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message + ".\n");
            }
        }
        private static void HandleKeyEvent(object sender, AuthenticationPromptEventArgs e)
        {
            foreach (AuthenticationPrompt prompt in e.Prompts)
            {
                if (prompt.Request.IndexOf("Password:", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    prompt.Response = Password;
                }
            }
        }
        static void Main(string[] args)
        {
            cargar_SFTP(@"/remote/path/test/", @local_path);
            Console.Write("Press any key to close CLI.\n");
            Console.ReadLine();
        }
    }
}
