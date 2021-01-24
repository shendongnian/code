using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
namespace ezCPU
{
    public partial class ezCPU : Form
    {
        //Create objects of each class that is needed
        CPU cpu = new CPU();
        GPU gpu = new GPU();
        Motherboard mb = new Motherboard();
        Memory mem = new Memory();
        //Variable to hold the new app version
        string newVersion = "";
        //Constructor
        public ezCPU()
        {
            InitializeComponent();
        }
        //On load, do this
        private void ezCPU_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Application.StartupPath + "/ezCPU(2).exe"))
            {
                Console.WriteLine("EXISTS");
                System.IO.File.Delete(Application.StartupPath + "/ezCPU(2).exe");
            }
            this.Text = this.Text + " - v" + Application.ProductVersion;
            this.abVersion.Text = "Version: " + Application.ProductVersion;
            //Call CPU class and display the results
            cpu.GetCPUInfo();
            DisplayCPUStats();
            //Call the GPU class and display the results
            gpu.GetGPUInfo();
            DisplayGPUStats();
            //Call the motherboard class and display the results
            mb.GetMBInfo();
            DisplayMBStats();
            //Call the memory class and display the results
            mem.GetRAMInfo();
            DisplayMemoryStats();
        }
        //Pulls the information from the CPU class to display it on the form
        public void DisplayCPUStats()
        {
            txtCPUName.Text = cpu.cpuName;
            if (cpu.cpuManufacturer.Contains("Intel"))
            {
                txtCPUManufacturer.Text = "Genuine Intel";
            }
            else
            {
                txtCPUManufacturer.Text = cpu.cpuManufacturer;
            }
            txtCores.Text = cpu.cpuCores;
            txtThreads.Text = cpu.cpuThreads;
            txtMaxSpeed.Text = cpu.ConvertClockSpeed(cpu.cpuMaxSpeed);
            txtCurrentSpeed.Text = cpu.ConvertClockSpeed(cpu.cpuCurrentSpeed);
            txtCaption.Text = cpu.cpuCaption;
            txtStatus.Text = cpu.cpuStatus;
            txtArchitecture.Text = cpu.GetArchitecture(Convert.ToInt16(cpu.cpuArchitecture));
        }
        //Pulls the information from the GPU class to display it on the form
        public void DisplayGPUStats()
        {
            txtGPUName.Text = gpu.gpuName;
            txtGPUManufacturer.Text = gpu.gpuManufacturer;
            txtGPUVideoMode.Text = gpu.gpuVideoMode;
            txtGPURefresh.Text = gpu.gpuRefreshRate + " hertz";
            txtGPUStatus.Text = gpu.gpuStatus;
            txtGPUDriverVersion.Text = gpu.gpuDriverVersion;
            txtGPUDriverDate.Text = gpu.gpuDriverDate;
        }
        
        //Pulls the information from the Motherboard class to display it on the form
        public void DisplayMBStats()
        {
            //Motherboard information
            txtMBManufacturer.Text = mb.mbManufacturer;
            txtMBModel.Text = mb.mbModel;
            txtMBSerial.Text = mb.mbSerial;
            txtMBBusType.Text = mb.mbBusType;
            txtMBStatus.Text = mb.mbStatus;
            //BIOS information
            txtBIOSVersion.Text = mb.biosVersion;
            txtBIOSDate.Text = mb.biosDate;
            txtBIOSBrand.Text = mb.biosManufacturer;
        }
        //Pulls the information from the Memory class to display it on the form
        public void DisplayMemoryStats()
        {
            //RAM information
            txtRAMSize.Text = mem.BytesToGB(mem.ramSize);
            txtRAMManufacturer.Text = mem.ramManufacturer;
            txtRAMType.Text = mem.GetRAMType(Convert.ToInt16(mem.ramType));
            txtRAMFrequency.Text = String.Format("{0:n1}", Convert.ToInt16(mem.ramFrequency)) + " MHz";
        }
        //Visit the GitHub repo on click
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ioschris/ezCPU");
        }
        //Check for update and download if it exists
        public void DownloadUpdate()
        {
            //URL of the updated file
            string url = "http://www.chrisharrisdev.com/ezcpu/ezCPU.exe";
            //Declare new WebClient object
            WebClient wc = new WebClient();
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
            wc.DownloadFileAsync(new Uri(url), Application.StartupPath + "/ezCPU(1).exe");
        }
        //When the download completes, show the message box and restart the application
        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Show a message when the download has completed
            MessageBox.Show("ezCPU is now up-to-date!\n\nThe application will now restart!", "ezCPU - Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }
        //Create method to check for an update
        public void GetUpdate()
        {
            //Declare new WebClient object
            WebClient wc = new WebClient();
            string textFile = wc.DownloadString("http://www.chrisharrisdev.com/ezcpu/ezcpu_version.txt");
            newVersion = textFile;
            //If there is a new version, call the DownloadUpdate method
            if (newVersion != Application.ProductVersion)
            {
                MessageBox.Show("An update is available!\n\nClick OK to download and restart!", "ezCPU - Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DownloadUpdate();
            }
            else
            {
                MessageBox.Show("ezCPU is up-to-date!\n\nThere is not an update that needs to be applied!", "ezCPU - Up-to-Date", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //When the app restarts, rename the updated file, rename the original file, and delete the old version
        private void ezCPU_FormClosed(object sender, FormClosedEventArgs e)
        {
            //This renames the original file so any shortcut works and names it accordingly after the update
            if (System.IO.File.Exists(Application.StartupPath + "/ezCPU(1).exe"))
            {
                System.IO.File.Move(Application.StartupPath + "/ezCPU.exe", Application.StartupPath + "/ezCPU(2).exe");
                System.IO.File.Move(Application.StartupPath + "/ezCPU(1).exe", Application.StartupPath + "/ezCPU.exe");
            }
        }
        //Check for updates
        private void button1_Click(object sender, EventArgs e)
        {
            GetUpdate();
        }
    }
}
