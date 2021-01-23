    public static void deleteDocuments(List<string> arrayList)
    {
        foreach (var item in arrayList)
        {
            bool retry = false;
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
                    System.Threading.Thread.Sleep(500);
                    retry = true;
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
