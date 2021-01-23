    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    //{
    using System.Diagnostics;
    //}
    
    namespace ClickToWord
    {
        public partial class Form1 : Form
        {
            //{
            Process imsWord = new Process();
            Timer tempTime = new Timer();
            int counter = 0;
            //}
    
            public Form1()
            {
                InitializeComponent();
                //{
                imsWord.StartInfo.FileName = @"";
                //Inside the "" put the path to the file/application. No need to escape it, because of the "@"
                tempTime.Interval = 1000;
                //The interval in miliseconds
                tempTime.Tick += new EventHandler(tempTime_Tick);
                //}
            }
    
            void tempTime_Tick(object sender, EventArgs e)
            {
                //{
                char send = 'a';
                send += (char)(counter % 26);
                SendKeys.Send(send.ToString());
                counter++;
                //An example of looping through the alphabet. Send any string via SendKeys, and it will act as if the keyboard ent it.
                //This mimics keyboard strokes, and requires the document to have focus. That is why it is not the ideal way to do this.
                //To programmatically communicate with Word, use the Microsoft Word Object Model library.
                //tempTime.Enabled = false;
                //}
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //{
                imsWord.Start();
                //Starts the proccess
                tempTime.Enabled = true;
                //Starts the timer
                //}
            }
        }
    }
