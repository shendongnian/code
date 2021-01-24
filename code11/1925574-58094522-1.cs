    using Microsoft.Build.BuildEngine;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Threading;
    
    namespace RebuildAndReloadWPF
    {
        /// <summary>
       /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            const string projectPath = @"C:\...\Some-Project.csproj";
            const string libFileName = "Some-Lib.dll";
            const string ClassName = "NameSpace.UserControlName";
    
    
            private string projectFileName;
            private string projectDirectoryPath;
            private string projectBinPath;
            private string logFilePath;
            private string appDirectoryPath;
            private DispatcherTimer indicatorTimer = new DispatcherTimer();
    
    
            public MainWindow ()
            {
                projectFileName = Path.GetFileName(projectPath);
                projectDirectoryPath = Path.GetDirectoryName(projectPath);
                projectBinPath = projectDirectoryPath + @"\bin\Debug";
                logFilePath = projectDirectoryPath + @"\bin\Debug\build.log";
                appDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
                indicatorTimer = new DispatcherTimer();
                indicatorTimer.Interval = TimeSpan.FromMilliseconds(4000);
                indicatorTimer.Tick += ( sender, e ) =>
                {
                    elmJustNowIndicator.Visibility = Visibility.Hidden;
                    indicatorTimer.IsEnabled = false;
                };
    
                InitializeComponent();
            }
    
    
            public void ReloadContainer ()
            {
                PlaceHolder.Content = null;
    
                bool result = RunMsBuild();
    
                if (!result)
                {
                    txtIndicator.Text = "Compile error, see in log file. Compile fail at: " + DateTime.Now.ToLongTimeString();
                    txtIndicator.Foreground = Brushes.Red;
                    return;
                }
                else
                {
                    txtIndicator.Text = "Last build at: " + DateTime.Now.ToLongTimeString();
                    txtIndicator.Foreground = Brushes.Green;
                }
    
                try
                {
                    File.Copy(projectBinPath + @"\" + libFileName, appDirectoryPath + libFileName, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't copy compiled lib file: " + ex.Message);
                    throw;
                }
    
                elmJustNowIndicator.Visibility = Visibility.Visible;
                indicatorTimer.IsEnabled = false;
                indicatorTimer.IsEnabled = true;
    
                try
                {
                    PlaceHolder.Content = AsmLoad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Laod assembly error" + ex.Message);
                }
    
                GC.Collect();
            }
    
    
            public bool RunMsBuild ()
            {
                Engine eng = new Engine();
    
                FileLogger logger = new FileLogger();
                logger.Parameters = "logfile=" + logFilePath;
                eng.RegisterLogger(logger);
    
                bool bb = eng.BuildProjectFile(projectPath);
                eng.UnregisterAllLoggers();
                return bb;
            }
    
            public FrameworkElement AsmLoad ()
            {
                byte[] assemblyFileBUffer = File.ReadAllBytes(appDirectoryPath + @"\" + libFileName);
                Assembly asm = AppDomain.CurrentDomain.Load(assemblyFileBUffer);
                ContentControl container = (ContentControl)asm.CreateInstance(ClassName);
                return (FrameworkElement)container.Content;
            }
    
    
            private void Window_Activated ( object sender, EventArgs e )
            {
                if (chkReloadOnFocus.IsChecked == true)
                    ReloadContainer();
            }
    
            private void Button_Click ( object sender, RoutedEventArgs e )
            {
                ReloadContainer();
            }
        }
    }
