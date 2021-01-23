    public partial class MainPage : PhoneApplicationPage
    {   
        SoundEffectInstance loopedSound = null;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
    
        static protected void LoopClip(SoundEffect soundEffect)
        {
            loopedSound = soundEffect.CreateInstance();
            loopedSound.IsLooped = true;
            loopedSound.Play();
        }
    
        public void PlaySound(string soundFile)
        {
            SoundEffect sound = SoundEffect.FromStream(Application.GetResourceStream(new Uri(soundFile, UriKind.Relative)).Stream);
            SoundEffectInstance instance = sound.CreateInstance();
            instance.Play();
        }
    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SoundEffect sound = SoundEffect.FromStream(Application.GetResourceStream(new Uri(@"BackgroundMusic.wav", UriKind.Relative)).Stream); 
            LoopClip(sound);
        }
    
    
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            PlaySound("sound3.wav");
        }
    
    }
