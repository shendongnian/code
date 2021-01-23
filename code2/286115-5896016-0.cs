     using (ZipFile zip = new ZipFile())
            {
                foreach (String filename in FilesList)
                {
                    Console.WriteLine("Adding {0}...", filename);
                    ZipEntry e = zip.AddFile(filename,"");
                    e.Comment = "file " +filename+" added "+DateTime.Now;
                }
                Console.WriteLine("Done adding files to zip:" + zipName);
                zip.Comment = String.Format("This zip archive was created by '{0}' on '{1}'",
                   System.Net.Dns.GetHostName(), DateTime.Now);
                zip.Save(zipName);
                Console.WriteLine("Zip made:" + zipName);
            }
