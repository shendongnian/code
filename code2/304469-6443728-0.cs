    using System;
    using System.Windows.Forms;
    using SpeechLib;
    
    namespace SpeechDemo
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                //get installed voices
    	        SpVoice voice = new SpVoice();
                foreach (var item in voice.GetVoices())
                {
                    comboBox1.Items.Add(((ISpeechObjectToken)item).GetDescription());
                }
            }
    
            private void btnSpeakPhonems_Click(object sender, EventArgs e)
            {
                if (comboBox1.SelectedIndex > 0)
                {
                    SpVoice voice = new SpVoice();
                    voice.Voice = voice.GetVoices().Item(comboBox1.SelectedIndex);
                    voice.Speak("<pron sym=\"ang 1 zang 1\">变脏</pron>", SpeechVoiceSpeakFlags.SVSFlagsAsync);
    
                }
            }
        }
    }
