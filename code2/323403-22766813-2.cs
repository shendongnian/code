    {
    // Define a service contract.
    [ServiceContract(Namespace = "http://MyDataServices.foo.com")]
    public interface IDataService
    {
        [OperationContract]
        bool ProcessStatTransfer(MemoryStream inputCommands, string inputName);
    }
    // Implement the IDataService service contract in a service class.
    public class DataService : IDataService
    {
        // Implement the IDataService methods.
        public bool ProcessStatTransfer(MemoryStream inputCommands, string inputName)
        {
            try
            {
                // StatTransferLocation is C:\Program Files\StatTransfer12-64\st.exe
                // on the machine that hosts the service
                string m_stattransfer_loc = ConfigurationManager.AppSettings["StatTransferLocation"].ToString();
                string m_stattransfer_file = ConfigurationManager.AppSettings["CommandFiles"].ToString() + inputName;
                using (FileStream m_fsfile = new FileStream(m_stattransfer_file, FileMode.Create, FileAccess.Write))
                {
                    inputCommands.WriteTo(m_fsfile);
                }
                ProcessStartInfo processInfo = new ProcessStartInfo("\"" + m_stattransfer_loc + "\"");
                processInfo.Arguments = "\"" + m_stattransfer_file + "\"";
                processInfo.UseShellExecute = false;
                processInfo.ErrorDialog = false;
                processInfo.CreateNoWindow = true;
                Process batchProcess = new Process();
                batchProcess.StartInfo = processInfo;
                batchProcess.Start();
                return true;
            }
            catch 
            {
                return false;
            }
 
        }
    .....
