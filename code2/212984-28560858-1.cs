    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    using System.Media; // at first you've to import this package to access SoundPlayer
    
    namespace WindowsFormsApplication1
    {
        public partial class login : Form
        {
            public login()
            {
                InitializeComponent();
            }
    
            private void login_Load(object sender, EventArgs e)
            {
                playaudio(); // calling the function
            }
    
            private void playaudio() // defining the function
            {
                SoundPlayer audio = new SoundPlayer(WindowsFormsApplication1.Properties.Resources.Connect); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name
                audio.Play();
            }
        }
    }
