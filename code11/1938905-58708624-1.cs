    var filename = "";
            var source = image.Source as FileImageSource;
            if (source != null)
            {
                filename = source.File;
            }
            var savingFile = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
            //var savingFile1 = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "save.png");
            var S = DependencyService.Get<IDependency>().DrawableByNameToByteArray(filename);
            if (!File.Exists(savingFile))
            {
                File.WriteAllBytes(savingFile, S.ToArray());               
            }
