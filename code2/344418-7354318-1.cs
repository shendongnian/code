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
                String text1 = textBox1.Text;  
                String text2 = textBox2.Text;  
                String text3 = textBox3.Text;  
                string text = text1 + "." + text2 + "." + text3; 
                MessageBox.Show(text);           
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
