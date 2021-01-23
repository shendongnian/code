    <Grid x:Name="LayoutRoot" Background="Transparent">
        <phone:WebBrowser 
            Name="MyWebBrowserControl"
            HorizontalAlignment="Stretch" VerticalAlignment="Stretch" Margin="0" />
    </Grid>
----
    IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
            // if image file does not exist in isolated storage, copy it to there~!
            if (!isf.FileExists(filename))
            {
                StreamResourceInfo sr = Application.GetResourceStream(new Uri(filename, UriKind.Relative));
                using (BinaryReader br = new BinaryReader(sr.Stream))
                {
                    byte[] data = br.ReadBytes((int)sr.Stream.Length);
                    using (BinaryWriter bw = new BinaryWriter(isf.OpenFile(filename, FileMode.OpenOrCreate)))
                    {
                        bw.Write(data);
                        bw.Close();
                    }
                    br.Close();
                }
            }
            Dispatcher.BeginInvoke(() => { MyWebBrowserControl.Navigate(new Uri(filename, UriKind.Relative)); });
