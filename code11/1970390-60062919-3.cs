using Microsoft.Management.Infrastructure;
using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
namespace Test
{
    
    public class Program 
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd,UInt32 Msg, IntPtr wParam,IntPtr lParam);
        [DllImport("user32.dll")]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        static extern IntPtr PostMessage(IntPtr hwndParent, int msg, int wParam, IntPtr lParam);
        const int BM_CLICK = 0x00F5; //message for Click which is a constant
        const int WM_LBUTTONDOWN = 0x0201; //message for Mouse down
        const int WM_LBUTTONUP = 0x0202; // message for Mouse up
        static void Main(string[] args)
        {
            
           //Get the MainWindow handle of the Form1 APp
            var windowHandle = FindWindow(null, "Form1");
            //Using the Handle To Bring it to foreground
            SetForegroundWindow(windowHandle);
            System.Threading.Thread.Sleep(2000);
            
           //Getting the ButtonHandle for the different UI Controls, last param is the ControlText displayed on the UI 
            var btnHandle = FindWindowEx(windowHandle, IntPtr.Zero, null, "ButtonText");
            var txtHandle = FindWindowEx(windowHandle, IntPtr.Zero, null, "TextBoxText");
            var lblHandle = FindWindowEx(windowHandle, IntPtr.Zero, null, "LabelText");
            var chkBoxHandle = FindWindowEx(windowHandle, IntPtr.Zero, null, "CheckBoxText");
            System.Threading.Thread.Sleep(2000);
          
           
            //With the UI handle identified, we are passing the message(2nd param) that we have identified from Spy++
            SendMessage(btnHandle, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
            System.Threading.Thread.Sleep(2000);
            SendMessage(chkBoxHandle, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);//ButtonDown
            SendMessage(chkBoxHandle, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);//ButtonUp
            System.Threading.Thread.Sleep(2000);
            SendMessage(txtHandle, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            SendMessage(txtHandle, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
            System.Threading.Thread.Sleep(2000);
            SendMessage(lblHandle, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            SendMessage(lblHandle, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
            
        }
      
    }
}
<br>
----------
 - Simple **Winform App** to recreate the problem
**WinForm Form1.cs**
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
           
            public Form1()
            {
                InitializeComponent();
                
            }
    
    
            int counter = 0;
            private void button1_Click(object sender, System.EventArgs e)
            {
              
                textBox1.Text = counter++.ToString();
            }
    
            private void label1_Click(object sender, System.EventArgs e)
            {
                MessageBox.Show("You got me !!");
            }
    
        }
    }
**WinForm Form1.Designer.CS**
using System.Drawing;
namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(318, 200);
            this.button1.TabIndex = 1;
            this.button1.Text = "ButtonText";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(641, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "TextBoxText";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(400, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 21);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "CheckBoxText";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(615, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "LabelText";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
    }
}
**Output:**
The program would click `Button` then tick `CheckBox` then selects `TextBox` and then clicks `Label`
[![enter image description here][3]][3]
  [1]: https://i.stack.imgur.com/VFYdH.png
  [2]: https://i.stack.imgur.com/rDXsE.png
  [3]: https://i.stack.imgur.com/JdCUr.gif
