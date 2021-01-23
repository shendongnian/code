    public partial class MainPage : PhoneApplicationPage
    {   
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
    
    
    
        static protected void LoopClip(SoundEffect soundEffect)
        {
            SoundEffectInstance instance = soundEffect.CreateInstance();
            instance.IsLooped = true;
            instance.Play();
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
