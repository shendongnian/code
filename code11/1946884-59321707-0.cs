    public static void SaveMusicToDisk(){
        //This sets up a new temporary file in the %temp% location called "backgroundmusic.wav"
        using (FileStream fileStream = File.Create(Path.GetTempPath() + "backgroundmusic.wav")){
            
            //This them looks into the assembly and finds the embedded resource
            //inside the WPF project, under the assets folder
            //under the sounds folder called backgroundmusic.wav
            //PLEASE NOTE: this will be different to you
            Assembly.GetExecutingAssembly().GetManifestResourceStream("WPF.Assets.Sounds.backgroundmusic.wav").CopyTo(fileStream);
        }
    }
