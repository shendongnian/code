    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using KeyVaultSample.Data;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.Services.AppAuthentication;
    using Microsoft.AspNetCore.DataProtection;
    using Microsoft.AspNetCore.DataProtection.KeyManagement;
    using Microsoft.AspNetCore.DataProtection.AzureStorage;
    
    
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.Rest;
    using Microsoft.WindowsAzure.Storage.Auth;
    
    namespace KeyVaultSample
    {
        public class DataProtectionSettings
        {
            public string KeyVaultKeyId { get; set; }
            public string AadTenantId { get; set; }
            public string StorageAccountName { get; set; }
            public string StorageKeyContainerName { get; set; }
            public string StorageKeyBlobName { get; set; }
        }
        public class Startup
        {
            private readonly AzureServiceTokenProvider _tokenProvider;
    
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
                _tokenProvider = new AzureServiceTokenProvider();
            }
    
            public IConfiguration Configuration { get; }
    
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.Configure<CookiePolicyOptions>(options =>
                {
                    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });
    
                var settings = Configuration.GetSection("DataProtection").Get<DataProtectionSettings>();
    
                var kvClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(_tokenProvider.KeyVaultTokenCallback));
    
                services.AddDataProtection()
                    .ProtectKeysWithAzureKeyVault(kvClient, settings.KeyVaultKeyId);
                // Replicates PersistKeysToAzureBlobStorage
                // There is no overload to give it the func it ultimately uses
                // We need to do that so that we can get refreshed tokens when needed
                services.Configure<KeyManagementOptions>(options =>
                {
                    options.XmlRepository = new AzureBlobXmlRepository(() =>
                    {
                        // This func is called every time before getting the blob and before modifying the blob
                        // Get access token for Storage
                        // User / managed identity needs Blob Data Contributor on the Storage Account (container was not enough)
                        string accessToken = _tokenProvider.GetAccessTokenAsync("https://storage.azure.com/", tenantId: settings.AadTenantId)
                     .GetAwaiter()
                     .GetResult();
                        // Create blob reference with token
                        var tokenCredential = new TokenCredential(accessToken);
                        var storageCredentials = new StorageCredentials(tokenCredential);
                        var uri = new Uri($"https://{settings.StorageAccountName}.blob.core.windows.net/{settings.StorageKeyContainerName}/{settings.StorageKeyBlobName}");
                        // Note this func is expected to return a new instance on each call
                        var blob = new CloudBlockBlob(uri, storageCredentials);
                        return blob;
                    });
                });
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection")));
                services.AddDefaultIdentity<IdentityUser>()
                    .AddDefaultUI(UIFramework.Bootstrap4)
                    .AddEntityFrameworkStores<ApplicationDbContext>();
    
    
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseDatabaseErrorPage();
                }
                else
                {
                    app.UseExceptionHandler("/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }
    
                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseCookiePolicy();
    
                app.UseAuthentication();
    
                app.UseMvc();
            }
        }
    }
