    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
      {
          webBuilder.UseKestrel(options =>
          {
            options.Listen(System.Net.IPAddress.Parse(DomainIp), 80);
            options.Listen(System.Net.IPAddress.Parse(DomainIp), 443, l =>
            {
              l.UseHttps(
                DomainCertificateFile,
                DomainCertificatePassword);
              l.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1;
            });
          });
          webBuilder.UseStaticWebAssets();
          webBuilder.UseStartup<Startup>();
       });
