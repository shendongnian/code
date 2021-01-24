 lang-xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <system.webServer>
    <security>
      <requestFiltering>
        <!-- 4294967295 bytes (4 GiB) is the maximum value-->
        <requestLimits maxAllowedContentLength="52428800" />
      </requestFiltering>
    </security>
  </system.webServer>
</configuration>
You can also set FormOptions in your StartUp class:
 lang-C#
public void ConfigureServices(IServiceCollection services)
{
    // Set limits for form options, to accept big data
    services.Configure<FormOptions>(x =>
    {
        x.BufferBody = false;
        x.KeyLengthLimit = 2048; // 2 KiB
        x.ValueLengthLimit = 4194304; // 32 MiB
        x.ValueCountLimit = 2048;// 1024
        x.MultipartHeadersCountLimit = 32; // 16
        x.MultipartHeadersLengthLimit = 32768; // 16384
        x.MultipartBoundaryLengthLimit = 256; // 128
        x.MultipartBodyLengthLimit = 134217728; // 128 MiB
    });
    // Add the mvc framework
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    ...
} // End of the ConfigureServices method
Another option is send smaller chunks of ArchivePlugs.
