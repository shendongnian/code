    using System.Media;
    public SoundPlayer LoadSoundFile(string filename)
    {
           SoundPlayer sound = null;
   
           try
           {
                 sound = new SoundPlayer();
                 sound.SoundLocation = filename;
                 sound.Load();
           }
           catch (Exception ex)
           {
                 MessageBox.Show(ex.Message, "Error loading sound");
           }
         
           return sound;         
    }
