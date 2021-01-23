    private void WriteClick(object sender, RoutedEventArgs e)
    {
        using (var store = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (var fileStream = store.OpenFile("myfile.txt", FileMode.Create, FileAccess.Write))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(textItem1.Text);
                    writer.WriteLine(textItem2.Text);
                }
            }
        }
    }
    private void ReadClick(object sender, RoutedEventArgs e)
    {
        using (var store = IsolatedStorageFile.GetUserStoreForApplication())
        {
            if (store.FileExists("myfile.txt"))
            {
                using (var fileStream = store.OpenFile("myfile.txt", FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new StreamReader(fileStream))
                    {
                        textItem1.Text = reader.ReadLine();
                        textItem2.Text = reader.ReadLine();
                    }
                }
            }
        }
    }
