    using System; 
    using System.Collections.Generic; 
    using System.ComponentModel; 
    using System.Data; 
    using System.Drawing; 
    using System.Linq; 
    using System.Text; 
    using System.Windows.Forms; 
     
    namespace UpdaterForm 
    { 
        public partial class Form1 : Form 
        { 
            public Form1() 
            { 
                InitializeComponent(); 
            } 
     
            private void Form1_Load(object sender, EventArgs e) 
            { 
     
            } 
     
            private void label1_Click(object sender, EventArgs e) 
            { 
     
            } 
     
            private void button1_Click(object sender, EventArgs e) 
            { 
                String text1; 
                String text2; 
                String text3; 
                text1 = form.textbox1; 
                text2 = form.textbox2; 
                text3 = form.textbox3; 
                string text = text1 + "." + text2 + "." + text3; 
                MessageBox.Show(text);           
            } 
            private void textBox1_TextChanged(object sender, EventArgs e) 
            { 
                this.Text=textBox1.Text; 
            } 
     
            public String textbox1 
            { 
                get{ 
                      return textBox1.Text; 
                } 
            } 
     
     
            public String textbox2 
            { 
                get 
                { 
                    return textBox2.Text; 
                } 
            } 
     
            public String textbox3 
            { 
                get 
                { 
                    return textBox3.Text; 
                } 
            } 
     
        } 
    } 
     
    using System; 
    using System.Collections.Generic; 
    using System.Linq; 
    using System.Text; 
     
    using System.Windows.Forms; 
     
    namespace UpdaterForm 
    { 
        public class UpdaterForm 
        { 
            public string PickText( ) 
            { 
                Form1 form = new Form1(); 
     
                try {
                  Application.Run(form); 
                } finally {
                  form.Dispose();
                } 
            } 
        } 
    } 
