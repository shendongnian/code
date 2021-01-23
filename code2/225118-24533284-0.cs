    //--------------------------------------------------------------------
    // FILENAME: Form1.cs
    //
    // Copyright © 2011 Motorola Solutions, Inc. All rights reserved.
    //
    // DESCRIPTION:
    //
    // NOTES:
    //
    // 
    //--------------------------------------------------------------------
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using Symbol.Barcode;
    using Symbol.Barcode2;
    using System.IO.Ports;
    
    namespace CS_Barcode2ControlSample1
    {
        public partial class Form1 : Form
        {
            SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
    
            private static bool bPortrait = true;   // The default dispaly orientation 
            // has been set to Portrait.
    
            private bool bSkipMaxLen = false;    // The restriction on the maximum 
            // physical length is considered by default.
    
            private bool bInitialScale = true;   // The flag to track whether the 
            // scaling logic is applied for
            // the first time (from scatch) or not.
            // Based on that, the (outer) width/height values
            // of the form will be set or not.
            // Initially set to true.
    
            private int resWidthReference = 240;   // The (cached) width of the form. 
            // INITIALLY HAS TO BE SET TO THE WIDTH OF THE FORM AT DESIGN TIME (IN PIXELS).
            // This setting is also obtained from the platform only on
            // Windows CE devices before running the application on the device, as a 
    
    verification.
            // For PocketPC (& Windows Mobile) devices, the failure to set this properly may 
    
    result in the distortion of GUI/viewability.
    
            private int resHeightReference = 268;  // The (cached) height of the form.
            // INITIALLY HAS TO BE SET TO THE HEIGHT OF THE FORM AT DESIGN TIME (IN PIXELS).
            // This setting is also obtained from the platform only on
            // Windows CE devices before running the application on the device, as a 
    
    verification.
            // For PocketPC (& Windows Mobile) devices, the failure to set this properly may 
    
    result in the distortion of GUI/viewability.
    
            private const double maxLength = 5.5;  // The maximum physical width/height of 
    
    the sample (in inches).
            // The actual value on the device may slightly deviate from this
            // since the calculations based on the (received) DPI & resolution values 
            // would provide only an approximation, so not 100% accurate.
    
    
            public Form1()
            {
                InitializeComponent();
                timer1.Interval = 100;
                timer1.Enabled = true;
            }
    
            /// <summary>
            /// This function does the (initial) scaling of the form
            /// by re-setting the related parameters (if required) &
            /// then calling the Scale(...) internally. 
            /// </summary>
            /// 
            public void DoScale()
            {
                if (Screen.PrimaryScreen.Bounds.Width > Screen.PrimaryScreen.Bounds.Height)
                {
                    bPortrait = false; // If the display orientation is not portrait (so it's 
    
    landscape), set the flag to false.
                }
    
                if (this.WindowState == FormWindowState.Maximized)    // If the form is 
    
    maximized by default.
                {
                    this.bSkipMaxLen = true; // we need to skip the max. length restriction
                }
    
                if ((Symbol.Win32.PlatformType.IndexOf("WinCE") != -1) || 
    
    (Symbol.Win32.PlatformType.IndexOf("WindowsCE") != -1) || 
    
    (Symbol.Win32.PlatformType.IndexOf("Windows CE") != -1)) // Only on Windows CE devices
                {
                    this.resWidthReference = this.Width;   // The width of the form at design 
    
    time (in pixels) is obtained from the platorm.
                    this.resHeightReference = this.Height; // The height of the form at 
    
    design time (in pixels) is obtained from the platform.
                }
    
                Scale(this); // Initial scaling of the GUI
            }
    
            /// <summary>
            /// This function scales the given Form & its child controls in order to
            /// make them completely viewable, based on the screen width & height.
            /// </summary>
            private static void Scale(Form1 frm)
            {
                int PSWAW = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;    
    
    // The width of the working area (in pixels).
                int PSWAH = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;   
    
    // The height of the working area (in pixels).
    
                // The entire screen has been taken in to account below 
                // in order to decide the half (S)VGA settings etc.
                if (!((Screen.PrimaryScreen.Bounds.Width <= (1.5) * 
    
    (Screen.PrimaryScreen.Bounds.Height))
                && (Screen.PrimaryScreen.Bounds.Height <= (1.5) * 
    
    (Screen.PrimaryScreen.Bounds.Width))))
                {
                    if ((Screen.PrimaryScreen.Bounds.Width) > 
    
    (Screen.PrimaryScreen.Bounds.Height))
                    {
                        PSWAW = (int)((1.33) * PSWAH);  // If the width/height ratio goes 
    
    beyond 1.5,
                        // the (longer) effective width is made shorter.
                    }
    
                }
    
                System.Drawing.Graphics graphics = frm.CreateGraphics();
    
                float dpiX = graphics.DpiX; // Get the horizontal DPI value.
    
                if (frm.bInitialScale == true) // If an initial scale (from scratch)
                {
                    if (Symbol.Win32.PlatformType.IndexOf("PocketPC") != -1) // If the 
    
    platform is either Pocket PC or Windows Mobile
                    {
                        frm.Width = PSWAW;  // Set the form width. However this setting
                        // would be the ultimate one for Pocket PC (& Windows Mobile)devices.
                        // Just for the sake of consistency, it's explicitely specified here.
                    }
                    else
                    {
                        frm.Width = (int)((frm.Width) * (PSWAW)) / (frm.resWidthReference); 
    
    // Set the form width for others (Windows CE devices).
    
                    }
                }
                if ((frm.Width <= maxLength * dpiX) || frm.bSkipMaxLen == true) // The 
    
    calculation of the width & left values for each control
                // without taking the maximum length restriction into consideration.
                {
                    foreach (System.Windows.Forms.Control cntrl in frm.Controls)
                    {
                        cntrl.Width = ((cntrl.Width) * (frm.Width)) / 
    
    (frm.resWidthReference);
                        cntrl.Left = ((cntrl.Left) * (frm.Width)) / (frm.resWidthReference);
    
                        if (cntrl is System.Windows.Forms.TabControl)
                        {
                            foreach (System.Windows.Forms.TabPage tabPg in cntrl.Controls)
                            {
                                foreach (System.Windows.Forms.Control cntrl2 in 
    
    tabPg.Controls)
                                {
                                    cntrl2.Width = (((cntrl2.Width) * (frm.Width)) / 
    
    (frm.resWidthReference));
                                    cntrl2.Left = (((cntrl2.Left) * (frm.Width)) / 
    
    (frm.resWidthReference));
                                }
                            }
                        }
                    }
    
                }
                else
                {   // The calculation of the width & left values for each control
                    // with the maximum length restriction taken into consideration.
                    foreach (System.Windows.Forms.Control cntrl in frm.Controls)
                    {
                        cntrl.Width = (int)(((cntrl.Width) * (PSWAW) * (maxLength * dpiX)) / 
    
    (frm.resWidthReference * (frm.Width)));
                        cntrl.Left = (int)(((cntrl.Left) * (PSWAW) * (maxLength * dpiX)) / 
    
    (frm.resWidthReference * (frm.Width)));
    
                        if (cntrl is System.Windows.Forms.TabControl)
                        {
                            foreach (System.Windows.Forms.TabPage tabPg in cntrl.Controls)
                            {
                                foreach (System.Windows.Forms.Control cntrl2 in 
    
    tabPg.Controls)
                                {
                                    cntrl2.Width = (int)(((cntrl2.Width) * (PSWAW) * 
    
    (maxLength * dpiX)) / (frm.resWidthReference * (frm.Width)));
                                    cntrl2.Left = (int)(((cntrl2.Left) * (PSWAW) * (maxLength 
    
    * dpiX)) / (frm.resWidthReference * (frm.Width)));
                                }
                            }
                        }
                    }
    
                    frm.Width = (int)((frm.Width) * (maxLength * dpiX)) / (frm.Width);
    
                }
    
                frm.resWidthReference = frm.Width; // Set the reference width to the new 
    
    value.
    
    
                // A similar calculation is performed below for the height & top values for 
    
    each control ...
    
                if (!((Screen.PrimaryScreen.Bounds.Width <= (1.5) * 
    
    (Screen.PrimaryScreen.Bounds.Height))
                && (Screen.PrimaryScreen.Bounds.Height <= (1.5) * 
    
    (Screen.PrimaryScreen.Bounds.Width))))
                {
                    if ((Screen.PrimaryScreen.Bounds.Height) > 
    
    (Screen.PrimaryScreen.Bounds.Width))
                    {
                        PSWAH = (int)((1.33) * PSWAW);
                    }
    
                }
    
                float dpiY = graphics.DpiY;
    
                if (frm.bInitialScale == true)
                {
                    if (Symbol.Win32.PlatformType.IndexOf("PocketPC") != -1)
                    {
                        frm.Height = PSWAH;
                    }
                    else
                    {
                        frm.Height = (int)((frm.Height) * (PSWAH)) / 
    
    (frm.resHeightReference);
    
                    }
                }
    
                if ((frm.Height <= maxLength * dpiY) || frm.bSkipMaxLen == true)
                {
                    foreach (System.Windows.Forms.Control cntrl in frm.Controls)
                    {
    
                        cntrl.Height = ((cntrl.Height) * (frm.Height)) / 
    
    (frm.resHeightReference);
                        cntrl.Top = ((cntrl.Top) * (frm.Height)) / (frm.resHeightReference);
    
    
                        if (cntrl is System.Windows.Forms.TabControl)
                        {
                            foreach (System.Windows.Forms.TabPage tabPg in cntrl.Controls)
                            {
                                foreach (System.Windows.Forms.Control cntrl2 in 
    
    tabPg.Controls)
                                {
                                    cntrl2.Height = ((cntrl2.Height) * (frm.Height)) / 
    
    (frm.resHeightReference);
                                    cntrl2.Top = ((cntrl2.Top) * (frm.Height)) / 
    
    (frm.resHeightReference);
                                }
                            }
                        }
    
                    }
    
                }
                else
                {
                    foreach (System.Windows.Forms.Control cntrl in frm.Controls)
                    {
    
                        cntrl.Height = (int)(((cntrl.Height) * (PSWAH) * (maxLength * dpiY)) 
    
    / (frm.resHeightReference * (frm.Height)));
                        cntrl.Top = (int)(((cntrl.Top) * (PSWAH) * (maxLength * dpiY)) / 
    
    (frm.resHeightReference * (frm.Height)));
    
    
                        if (cntrl is System.Windows.Forms.TabControl)
                        {
                            foreach (System.Windows.Forms.TabPage tabPg in cntrl.Controls)
                            {
                                foreach (System.Windows.Forms.Control cntrl2 in 
    
    tabPg.Controls)
                                {
                                    cntrl2.Height = (int)(((cntrl2.Height) * (PSWAH) * 
    
    (maxLength * dpiY)) / (frm.resHeightReference * (frm.Height)));
                                    cntrl2.Top = (int)(((cntrl2.Top) * (PSWAH) * (maxLength * 
    
    dpiY)) / (frm.resHeightReference * (frm.Height)));
                                }
                            }
                        }
    
                    }
    
                    frm.Height = (int)((frm.Height) * (maxLength * dpiY)) / (frm.Height);
    
                }
    
                frm.resHeightReference = frm.Height;
    
                if (frm.bInitialScale == true)
                {
                    frm.bInitialScale = false; // If this was the initial scaling (from 
    
    scratch), it's now complete.
                }
                if (frm.bSkipMaxLen == true)
                {
                    frm.bSkipMaxLen = false; // No need to consider the maximum length 
    
    restriction now.
                }
    
    
            }
    
            private void buttonExit_Click(object sender, EventArgs e)
            {
                // You must disable the scanner before exiting the application in 
                // order to release all the resources.
                barcode21.EnableScanner = false;
                this.Close();
                Application.Exit();
            }
            private void buttonExit_KeyDown(object sender, KeyEventArgs e)
            {
                // Checks if the key pressed was an enter button (character code 13)
                if (e.KeyValue == (char)13)
                    buttonExit_Click(this, e);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                // Add MainMenu if Pocket PC
                if (Symbol.Win32.PlatformType.IndexOf("PocketPC") != -1)
                {
                    this.Menu = this.mainMenu1;
                }
            }
    
            private void Form1_Resize(object sender, EventArgs e)
            {
                if (bInitialScale == true)
                {
                    return; // Return if the initial scaling (from scratch)is not complete.
                }
    
                if (Screen.PrimaryScreen.Bounds.Width > Screen.PrimaryScreen.Bounds.Height) 
    
    // If landscape orientation
                {
                    if (bPortrait != false) // If an orientation change has occured to 
    
    landscape
                    {
                        bPortrait = false; // Set the orientation flag accordingly.
                        bInitialScale = true; // An initial scaling is required due to 
    
    orientation change.
                        Scale(this); // Scale the GUI.
                    }
                    else
                    {   // No orientation change has occured
                        bSkipMaxLen = true; // Initial scaling is now complete, so skipping 
    
    the max. length restriction is now possible.
                        Scale(this); // Scale the GUI.
                    }
                }
                else
                {
                    // Similarly for the portrait orientation...
                    if (bPortrait != true)
                    {
                        bPortrait = true;
                        bInitialScale = true;
                        Scale(this);
                    }
                    else
                    {
                        bSkipMaxLen = true;
                        Scale(this);
                    }
                }
    
            }
    
            private void barcode21_OnScan(ScanDataCollection scanDataCollection)
            {
    			// Checks if the BeginInvoke method is required because the 
    
    OnScan delegate is called by a different thread
                if (this.InvokeRequired)
                {
    				// Executes the OnScan delegate asynchronously on the 
    
    main thread
                    this.BeginInvoke(new Symbol.Barcode2.Design.Barcode2.OnScanEventHandler
    
    (barcode21_OnScan), new object[] { scanDataCollection });
                }
                else
                {
                    ScanData scanData = scanDataCollection.GetFirst;
                    if (scanData.Result == Results.SUCCESS)
                    {
                        // Write the scanned data and type (symbology) to the list box
                        //listBox1.Items.Add(scanData.Text + ";" + scanData.Type.ToString());
                        string sData = scanData.Text;
                        // IUID Snowflake Header
                        if (sData.StartsWith("[)>"))
                        {
                            // Process IUID Scan Data
                            string unkStr = iuidScan(sData);
                        }
                        else if (sData.StartsWith("N"))
                        {
                            // Probable CAC Card Reading
                            txt2Send.Text = sData;
                            lstStatus.Items.Add("Probable CAC Scanned");
                        }
                        else
                        {
                            // Anything Else
                            txt2Send.Text = sData;
                            lstStatus.Items.Add("Unknown");
                        }
                    }
                }
            }
    
            private void barcode21_OnStatus(StatusData statusData)
            {
    			// Checks if the BeginInvoke method is required because the 
    
    OnStatus delegate is called by a different thread
                if (this.InvokeRequired)
                {
    				// Executes the OnStatus delegate asynchronously on the 
    
    main thread
                    this.BeginInvoke(new 
    
    Symbol.Barcode2.Design.Barcode2.OnStatusEventHandler(barcode21_OnStatus), new object[] { 
    
    statusData });
                }
                else
                {
                    statusBar1.Text = statusData.Text;
                }
            }
    
            private void Form1_Deactivate(object sender, EventArgs e)
            {
                barcode21.EnableScanner = false;
                this.Close();
                Application.Exit();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                // Port has to be Open to test DSR
                port.Open();
                if (port.DsrHolding == true)
                {
                    btnTransmit.Text = "Click To Transmit Data";
                    btnTransmit.Enabled = true;
                }
                else
                {
                    btnTransmit.Text = "Not Connected";
                    btnTransmit.Enabled = false;
                }
                port.Close();
            }
    
            private void btnTransmit_Click(object sender, EventArgs e)
            {
                port.Open();
                port.Write(txt2Send.Text);
                port.Write(new byte[] { 0x0A, 0x0D }, 0, 2);
                port.Close();
                txt2Send.Text = "";
                lstStatus.Items.Clear();
            }
    
            // A method for expanding ASCII Control Character into Human Readable format
            string ExpandCtrlString(string inStr)
            {
                // String Builder Capacity may need to be lengthened...
                StringBuilder outStr = new StringBuilder(128);
                // 0 Based Array representing the expansion of ASCII Control Characters
                string[] CtrlChars = new string[]
                {
                    "<nul>",
                    "<soh>",
                    "<stx>",
                    "<etx>",
                    "<eot>",
                    "<enq>",
                    "<ack>",
                    "<bel>",
                    "<bs>",
                    "<tab>",
                    "<lf>",
                    "<vt>",
                    "<ff>",
                    "<cr>",
                    "<so>",
                    "<si>",
                    "<dle>",
                    "<dc1>",
                    "<dc2>",
                    "<dc3>",
                    "<dc4>",
                    "<nak>",
                    "<syn>",
                    "<etb>",
                    "<can>",
                    "<em>",
                    "<sub>",
                    "<esc>",
                    "<fs>",
                    "<gs>",
                    "<rs>",
                    "<us>"
                };
    
                for (int n = 0; n < inStr.Length; n++)
                {
                    if (Char.IsControl(inStr, n))
                    {
                        int x = (int)(char)inStr[n];
                        outStr.Append(CtrlChars[x]);
                    }
                    else
                    {
                        outStr.Append(inStr.Substring(n, 1));
                    }
                }
                return outStr.ToString();
            }
    
            // IUID Data Was Scanned
            string iuidScan(string sData)
            {
                // We will temporarily Display an Expanded version of the Scanned Data
                txt2Send.Text = ExpandCtrlString(sData);
                lstStatus.Items.Add("IUID Scanned");
                // Get the format type
                string iuidFormat = sData.Substring(4, 2);
                lstStatus.Items.Add("Format: " + iuidFormat);
                
                // We are NOT currently supporting formats other than format 6
                if (iuidFormat != "06")
                {
                    lstStatus.Items.Add("Unacceptable Format!");
                    return "No Data";
                }
                string iuidType = sData.Substring(7, 3);
                string iuidConstruct = "0";
                // Have to If Else If because the iuidType is variable length
                string rData = "No Data";
                int kw = 10;    // 10 for start position when iuidType is 3 Characters
                switch(iuidType)
                {
                    case "18S":
                    case "25S":
                    case "22S":
                        iuidConstruct = "1";
                        rData = iuidConstruct1(sData, kw);
                        break;
                    case "17V":
                    case "12V":
                    case "18V":
                        iuidConstruct = "2";
                        rData = iuidConstruct2(sData, kw);
                        break;
                    default:
                        // Single and Two Digit Construct ID's not yet supported
                        iuidConstruct = "Unknown";
                        break;
                }
                lstStatus.Items.Add("Construct Identifier: " + iuidType);
                lstStatus.Items.Add("Construct: " + iuidConstruct);
                return "No data";
            }
            // Extraction Routine for IUID Construct 1
            string iuidConstruct1(string sData, int kw)
            {
                // Must Check for Concatenated Data
                int gsIndex = sData.IndexOf("\u001D", kw);
                if (gsIndex < 0)
                {
                    gsIndex = sData.IndexOf("\u001E", kw);
                    lstStatus.Items.Add("Does Not Have Appended Data");
                }
                else
                {
                    lstStatus.Items.Add("Has Appended Data");
                }
    
                string UII = "UII: D" + sData.Substring(kw, gsIndex - kw);
                string root = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                lstStatus.Items.Add("Root Path: " + root);
                System.IO.StreamReader file = new System.IO.StreamReader(@"\My Documents
    
    \MDMC.txt");
                string line;
                int counter = 0;
                int sl = UII.Length;
                line = file.ReadLine();
                lstStatus.Items.Add("Searching Database");
                while (line != null)
                {
                    lstStatus.Items.Add(line);
                    lstStatus.Refresh();
    
                    if (line.Length >= sl)
                    {
                        if (line.Substring(0, sl) == UII)
                        {
    
                            lstStatus.Items.Add("Counter: " + counter);
                            break;
                        }
                    }
                    if ((counter % 100) == 0)
                    {
                        lstStatus.Items.Add("Counter: " + counter);
                        lstStatus.Refresh();
                    }
                    line = file.ReadLine();
                    counter++;
                    if (counter >= 1000)
                    {
                        break;
                    }
                }
    
                file.Close();
    
                //txt2Send.Text = "kw: " + kw + " gsIndex: " + gsIndex + "\n\rsData: " + 
    
    sData + "\n\rsData: " + UII; 
    
                return "No Data";
            }
            
            // Extraction Routine for IUID Construct 2
            string iuidConstruct2(string sData, int kw)
            {
                // iuidConstruct = "2";
                int gsIndex = 0;
                string iuidEID = "Unknown"; // Enterprise Identifier. Often the CAGE Code
                gsIndex = sData.IndexOf("\u001D", kw);
                iuidEID = sData.Substring(10, gsIndex - kw);
                lstStatus.Items.Add(iuidEID);
                if (sData.Substring(gsIndex + 1, 2) == "1P")
                {
                    // Serial Number Applies
                    kw = gsIndex + 3;
                    gsIndex = sData.IndexOf("\u001D", kw);
                    string PartNumber = sData.Substring(kw, gsIndex - kw);
                    // We are asumming that a "S" exists after the <gs>
                    kw = gsIndex + 2;
                    // Must Check for <gs> because may contain Appended Data
                    // Returns -1 if <gs> not found, indicating no appended data.
                    gsIndex = sData.IndexOf("\u001D", kw);
                    if (gsIndex < 0)
                    {
                        gsIndex = sData.IndexOf("\u001E", kw);
                    }
                    else
                    {
                        lstStatus.Items.Add("Has Appended Data");
                    }
    
                    string SerialNumber = sData.Substring(kw, gsIndex - kw);
                    txt2Send.Text = "Gage: " + iuidEID + "\n\rPart Number: " + PartNumber + 
    
    "\n\rSerial Number: " + SerialNumber;
                }
                else
                {
                    // Assume '1T'. Serialization within Lot/Batch
    
                }
                return "No Data";
            }
            
    
        }
    }
