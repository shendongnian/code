        using System;
        using System.Threading;
        using System.Windows.Forms;
        using Microsoft.AspNetCore;
        using Microsoft.AspNetCore.Hosting;
        namespace MyWinFormsApp
        {
            public class Program
            {
                public static Form1 MainForm { get; private set; }
                [STAThread]
                public static void Main(string[] args)
                {
                    var t = new Thread(() =>
                    {
                        CreateWebHostBuilder(args).Build().Run();
                    });
                    t.IsBackground = true;
                    t.Start();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    MainForm = new Form1();
                    Application.Run(MainForm);
                }
                public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                    WebHost.CreateDefaultBuilder(args)
                        .UseStartup<Startup>();
            }
        }
