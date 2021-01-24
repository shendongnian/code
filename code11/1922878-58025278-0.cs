 cs
        //Dictionary with extensions
        static private Dictionary<string, string> filesType = new Dictionary<string, string>
        {
            { ".doc", "application/msword" },
            { ".jpg", "image/jpeg" },
            { ".jpeg", "image/jpeg" },
            { ".log", "text/plain" },
            { ".mp3", "audio/mp3" },
            { ".mp4", "video/mp4" },
            { ".pdf", "application/pdf" },
            { ".png", "image/png" },
            { ".rar", "application/x-rar-compressed" },
            { ".rtf", "application/rtf" },
            { ".txt", "text/plain" },
            { ".zip", "application/zip" },
        };
        //Open document
        static public void OpenDocument(string filePath)
        {
            var localFile = "file://" + filePath;
            Intent intent = new Intent();
            intent.AddFlags(ActivityFlags.NewTask);
            intent.SetAction(Intent.ActionView);
            string type = GetType(filePath);
            intent.SetDataAndType(Android.Net.Uri.Parse(localFile), type);
            Android.App.Application.Context.StartActivity(intent);
        }
        //Get file extesion
        static private string GetType(string filePath)
        {
            string extinsion = "";
            for (int i = filePath.Length - 1; i >= 0; i--)
            {
                if (filePath[i] != '.')
                    extinsion += filePath[i];
                else
                    break;
            }
            string reversedExtinson = ".";
            for (int i = extinsion.Length - 1; i >= 0; i--)
                reversedExtinson += extinsion[i];
            return filesType[reversedExtinson];
        } 
