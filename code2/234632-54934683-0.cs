        public void DownloadPdf(String downloadLink, String storageLink)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(downloadLink, storageLink);
            }
            Console.Write("Done!");
        }
        static void Main(string[] args)
        {
            Program test = new Program();
            test.DownloadPdf("*PDF file url here*", @"*save location here/filename.pdf*");
            Console.ReadLine();
        }
