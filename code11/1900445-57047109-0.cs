    using Microsoft.Win32;                  
    using System;                           
    using System.Drawing.Text;              
    using System.IO;                        
    using System.Runtime.InteropServices;   
    namespace TestAutomation
    {
        public partial class SplashScreen : Form
        {
            [DllImport("gdi32.dll", EntryPoint = "AddFontResource")]
            public static extern int AddFontResource(string lpFileName);
            [DllImport("gdi32.dll")]
            private static extern int CreateScalableFontResource(uint fdwHidden, string
            lpszFontRes, string lpszFontFile, string lpszCurrentPath);
            // <summary>
            // Installs font on the user's system and adds it to the registry so it's available on the next session
            // Your font must be embedded as a resource in your project with its 'Build Action' property set to 'Content' 
            // and its 'Copy To Output Directory' property set to 'Copy Always'
            // </summary>
            private void RegisterFont(string contentFontName)
            {
                DirectoryInfo dirWindowsFolder = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System));
                // Concatenate Fonts folder onto Windows folder.
                string strFontsFolder = Path.Combine(dirWindowsFolder.FullName, "Fonts");
                // Creates the full path where your font will be installed
                var fontDestination = Path.Combine(strFontsFolder, contentFontName);
                // Check if file exists in destination folder. If not, then copy the file from project directory to destination
                if (!File.Exists(fontDestination))
                {
                    try
                    {
                        // Copies font to destination
                        File.Copy(Path.Combine(Directory.GetCurrentDirectory(), contentFontName), fontDestination);
                        // Retrieves font name
                        PrivateFontCollection fontCol = new PrivateFontCollection();
                        fontCol.AddFontFile(fontDestination);
                        var actualFontName = fontCol.Families[0].Name;
                        // Add font
                        AddFontResource(fontDestination);
                        // Add registry entry   
                        Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts",
                            actualFontName, contentFontName, RegistryValueKind.String);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message + "\n\nThe required font(s) have not been installed."
                            + "\n\nPlease contact your systems administrator for help.");
                        Start();
                    }
                }
                // If file exists in destination folder, then start program.
                else
                {
                    Start();
                }
            }
            public SplashScreen()
            {
                RegisterFont("GOTHIC.TTF");
            }
            private void Start()
            {
                InitializeComponent();
            }
        }
    }
