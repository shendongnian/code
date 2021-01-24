    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Auth;
    using Serilog;
    using Serilog.Formatting.Json;
    using System;
    
    namespace AzureStorageTest
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var tokenCredential = new TokenCredential("<access token get from my account 
     whcih has the data contributor role of the stroage account that I am using now>");
                var storageCredential = new StorageCredentials(tokenCredential);
    
                var account = new CloudStorageAccount(storageCredential, "<my storage account name>", "core.windows.net", true);
    
                Log.Logger = new LoggerConfiguration().WriteTo.AzureBlobStorage(account).CreateLogger();
                Log.Logger.Error("aaaaa");
                Console.ReadKey();
            }
        }
    }
