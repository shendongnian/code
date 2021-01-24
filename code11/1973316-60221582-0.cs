        private void NavHomeView(object ID)
        {
            //return;
            if (IDis string destinationurl)
            {
                var link = new Uri(destinationurl);
                var psi = new ProcessStartInfo
                {
                    FileName = "cmd",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Arguments = $"/c start {link.AbsoluteUri}"
                };
                Process.Start(psi);
            ...
