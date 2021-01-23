        try
        {
            client.DownloadFile("http://www.xyz.com/download.php","abc.csv");
            Console.WriteLine("File Saved.");
        }
        catch (WebException we)
        {
            Console.WriteLine(we.Message + "\n" + we.Status.ToString());
        }
        catch (NotSupportedException ne)
        {
            Console.WriteLine(ne.Message);
        }
