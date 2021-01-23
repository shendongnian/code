    public class MediaPlayer
    {
        System.Media.SoundPlayer soundPlayer;
        public MediaPlayer(byte[] buffer)
        {
            var memoryStream = new MemoryStream(buffer, true);
            soundPlayer = new System.Media.SoundPlayer(memoryStream);
        }
        public void Play()
        {
            soundPlayer.Play();
        }
        public void Play(byte[] buffer)
        {
            soundPlayer.Stream.Seek(0, SeekOrigin.Begin);
            soundPlayer.Stream.Write(buffer, 0, buffer.Length);
            soundPlayer.Play();
        }
    }
