    public class Audio
    {
        private ContentManager content;
        public List<SoundEffectInstance> SoundInstance { get; private set; }
        public AudioEmitter Emitter { get; set; }
        public AudioListener Listener { get; set; }
        public List<SoundEffect> Sound { get; set; }
        public Audio(ContentManager content)
        {
            this.content = content;
            Emitter = new AudioEmitter();
            Listener = new AudioListener();
            Sound = new List<SoundEffect>();
            SoundInstance = new List<SoundEffectInstance>();
        }
        //set to null your sound instances and effects :D
        ~Audio()
        {
            Sound = null;
            SoundInstance = null;
        }
    ...
