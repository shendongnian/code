    public static void deleteDocuments(List<string> arrayList)
    {
        int maxRetries = 50;
        foreach (var item in arrayList)
        {
            bool retry = false;
            int retryCount = 0;
            do
            {
                try
                {
                    File.Delete(item);
                }
                catch(IOException ex)
                {
                    // This indicates file is in use, so sleep for
                    // half second and retry
                    retryCount++;
                    if (retryCount < maxRetries)
                    {
                        System.Threading.Thread.Sleep(500);
                        retry = true;
                    }
                    else
                    {
                        MessageBox.Show("Błąd kasowania: " + e.ToString(),
                            "Błąd Kasowania", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Błąd kasowania: " + e.ToString(),
                        "Błąd Kasowania", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            while(retry)
        }
    }
