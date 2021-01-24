        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using Amazon.Glacier;
        using Amazon.Glacier.Transfer;
        using Amazon.Runtime;
        namespace ConsoleApp9
        {
        class Program
        {
            static string vaultName = "TestVault";
            static string archiveToUpload = "C:\\Windows\\Temp\\TEST-ARCHIVE.txt";
            static void Main(string[] args)
            {
                try
                { 
                    var manager = new ArchiveTransferManager(Amazon.RegionEndpoint.USEast1);
                    // Upload an archive.
                    string archiveId = manager.Upload(vaultName, "upload archive test", archiveToUpload).ArchiveId;
                    Console.WriteLine("Archive ID: (Copy and save this ID for use in other examples.) : {0}", archiveId);
                    Console.WriteLine("To continue, press Enter");
                    Console.ReadKey();
                }
                catch (AmazonGlacierException e) { Console.WriteLine(e.Message); }
                catch (AmazonServiceException e) { Console.WriteLine(e.Message); }
                catch (Exception e) { Console.WriteLine(e.Message); }
                Console.WriteLine("To continue, press Enter");
                Console.ReadKey();
            }
        }
        }
