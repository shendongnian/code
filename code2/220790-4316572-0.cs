    using System;
    using System.Windows.Forms;
    using SKYPE4COMLib;
    namespace SkypeClient
    {
        public partial class Form1 : Form
        {
                public Form1()
                {
                    InitializeComponent();
                }
                private void button1_Click(object sender, EventArgs e)
                {
                     ISkype skype = new SkypeClass();
                     skype.Attach(5, true);
                     int count = skype.Chats.Count;
                     textBox1.Text = "Count: " + count + "\r\n";
                     foreach (IChat chat in skype.Chats)
                     {
                        textBox1.Text +=  "\r\n"  + chat.FriendlyName;
                     }
                }
           }
     }
