        private void SetPicture()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (var imgStream = assembly.GetManifestResourceStream("DataGrid.TestImage.jpg"))
            {
                var img = new Bitmap(imgStream);
                Picturebox.Image = img;
            }
        }
