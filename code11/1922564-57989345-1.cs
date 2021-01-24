     Java.IO.File sdCard = Android.OS.Environment.ExternalStorageDirectory;
     Java.IO.File dir = new Java.IO.File (sdCard.AbsolutePath + "/MyFolder");
     dir.Mkdirs ();
     Java.IO.File file = new Java.IO.File (dir,"download.txt");
        if (!file.Exists ()) {
            file.CreateNewFile ();
            file.Mkdir ();
            FileWriter writer = new FileWriter (file);
            // Writes the content to the file
            writer.Write (jsonData);
            writer.Flush ();
            writer.Close ();
        }
