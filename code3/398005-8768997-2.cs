       // Hinweis: Anweisungen zum Aktivieren des klassischen Modus von IIS6 oder IIS7 
        // finden Sie unter "http://go.microsoft.com/?LinkId=9394801".
        public class MvcApplication : System.Web.HttpApplication
        {
    
            [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
            static extern IntPtr LoadLibrary(string lpFileName);
    
            [System.Runtime.InteropServices.DllImport("kernel32", CharSet = System.Runtime.InteropServices.CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
            static extern UIntPtr GetProcAddress(IntPtr hModule, string procName);
    
            [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true)]
            [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
            static extern bool FreeLibrary(IntPtr hModule);
    
    
            // See http://mpi4py.googlecode.com/svn/trunk/src/dynload.h
            const int RTLD_LAZY = 1; // for dlopen's flags
            const int RTLD_NOW = 2; // for dlopen's flags
    
            [System.Runtime.InteropServices.DllImport("libdl")]
            static extern IntPtr dlopen(string filename, int flags);
    
            [System.Runtime.InteropServices.DllImport("libdl")]
            static extern IntPtr dlsym(IntPtr handle, string symbol);
    
            [System.Runtime.InteropServices.DllImport("libdl")]
            static extern int dlclose(IntPtr handle);
    
            [System.Runtime.InteropServices.DllImport("libdl")]
            static extern string dlerror();
    
    
            public void LoadSharedObject(string strFileName)
            {
                IntPtr hSO = IntPtr.Zero;
    
                try
                {
    
                    if (Environment.OSVersion.Platform == PlatformID.Unix)
                    {
                        hSO = dlopen(strFileName, RTLD_NOW);
                    }
                    else
                    {
                        hSO = LoadLibrary(strFileName);
                        
                    } // End if (Environment.OSVersion.Platform == PlatformID.Unix)
    
                } // End Try
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                } // End Catch
    
                if (hSO == IntPtr.Zero)
                {
                    throw new ApplicationException("Cannot open " + strFileName);
                } // End if (hExe == IntPtr.Zero)
    
            } // End Sub LoadSharedObject
    
    
            // http://stackoverflow.com/questions/281145/asp-net-hostingenvironment-shadowcopybinassemblies
            public void EnsureOracleDllsLoaded()
            {
                int iBitNess = IntPtr.Size * 8;
                
                string strTargetDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
                strTargetDirectory = System.IO.Path.GetDirectoryName(strTargetDirectory);
    
                string strSourcePath = "~/bin/dependencies/InstantClient/";
    
                if (Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    strSourcePath += "Linux" + iBitNess.ToString();
                }
                else
                {
                    strSourcePath += "Win" + iBitNess.ToString();
                }
    
                strSourcePath = Server.MapPath(strSourcePath);
    
                string[] astrAllFiles = System.IO.Directory.GetFiles(strSourcePath, "*.dll");
    
    
                foreach (string strSourceFile in astrAllFiles)
                {
                    string strTargetFile = System.IO.Path.GetFileName(strSourceFile);
                    strTargetFile = System.IO.Path.Combine(strTargetDirectory, strTargetFile);
                    System.IO.File.Copy(strSourceFile, strTargetFile, true);
    
                    //if(strTargetFile.EndsWith("orannzsbb11.dll", StringComparison.OrdinalIgnoreCase))
                    if (System.Text.RegularExpressions.Regex.IsMatch(strTargetFile, @"^(.*" + RegexDirSeparator + @")?orannzsbb11\.(dll|so|dylib)$", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        continue; // Unneeded exception thrower
                    
                    try
                    {
                        LoadSharedObject(strTargetFile);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
    
                } // Next strSourceFile
    
            } // End Sub EnsureOracleDllsLoaded
    
    
            public static void RegisterGlobalFilters(GlobalFilterCollection filters)
            {
                filters.Add(new HandleErrorAttribute());
            } // End Sub RegisterGlobalFilters
    
    
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
                routes.MapRoute(
                    "Default", // Routenname
                    "{controller}/{action}/{id}", // URL mit Parametern
                    //new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameterstandardwerte
                    new { controller = "Home", action = "Test", id = UrlParameter.Optional } // Parameterstandardwerte
                );
    
            } // End Sub RegisterRoutes
    
    
            protected void Application_Start()
            {
                EnsureOracleDllsLoaded();
                AreaRegistration.RegisterAllAreas();
    
                RegisterGlobalFilters(GlobalFilters.Filters);
                RegisterRoutes(RouteTable.Routes);
            } // End Sub Application_Start
    
    
        } // End Class MvcApplication : System.Web.HttpApplication
