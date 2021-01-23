        void wcMedia_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {       
            string iso_path="path where you want to put media file insode the isolated storage";
            var isolatedfile = IsolatedStorageFile.GetUserStoreForApplication();
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(iso_path, System.IO.FileMode.Create, isolatedfile))
            {
                byte[] buffer = new byte[e.Result.Length];
                while (e.Result.Read(buffer, 0, buffer.Length) > 0)
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
}
