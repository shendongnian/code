    this may help
    
    the code for user control:
    
    //usercontrol1.cs
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace WindowsFormsApplication1
    {
        public partial class UserControl1 : UserControl
        {
            Color formcolor;
            public UserControl1()
            {
                InitializeComponent();
    
            }
    
    
            public void setvals(string a1,string a2,string a3,string a4)
            {
                t1.Text=a1;
                t2.Text=a2;
                t3.Text=a3;
                t4.Text=a4;
            }
    
            public Color formColor
            {
                get
                {
                    return formcolor;
                }
                set
                {
                    formcolor = value;
                    this.BackColor = formcolor;
                }
            }
    
        }
    }
    
    
    
    
    
    usercontrol.designer.cs
    
    namespace WindowsFormsApplication1
    {
        partial class UserControl1
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
    
            #region Component Designer generated code
    
            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.t1 = new System.Windows.Forms.TextBox();
                this.t2 = new System.Windows.Forms.TextBox();
                this.t3 = new System.Windows.Forms.TextBox();
                this.t4 = new System.Windows.Forms.TextBox();
                this.SuspendLayout();
                // 
                // t1
                // 
                this.t1.Location = new System.Drawing.Point(20, 16);
                this.t1.Name = "t1";
                this.t1.Size = new System.Drawing.Size(100, 20);
                this.t1.TabIndex = 0;
                // 
                // t2
                // 
                this.t2.Location = new System.Drawing.Point(20, 42);
                this.t2.Name = "t2";
                this.t2.Size = new System.Drawing.Size(100, 20);
                this.t2.TabIndex = 1;
                // 
                // t3
                // 
                this.t3.Location = new System.Drawing.Point(20, 68);
                this.t3.Name = "t3";
                this.t3.Size = new System.Drawing.Size(100, 20);
                this.t3.TabIndex = 2;
                // 
                // t4
                // 
                this.t4.Location = new System.Drawing.Point(20, 94);
                this.t4.Name = "t4";
                this.t4.Size = new System.Drawing.Size(100, 20);
                this.t4.TabIndex = 3;
                // 
                // UserControl1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.Controls.Add(this.t4);
                this.Controls.Add(this.t3);
                this.Controls.Add(this.t2);
                this.Controls.Add(this.t1);
                this.Name = "UserControl1";
                this.Size = new System.Drawing.Size(278, 133);
                this.ResumeLayout(false);
                this.PerformLayout();
    
            }
    
            #endregion
    
            private System.Windows.Forms.TextBox t1;
            private System.Windows.Forms.TextBox t2;
            private System.Windows.Forms.TextBox t3;
            private System.Windows.Forms.TextBox t4;
        }
    }
    
    
    
    
    
    now in the form totally dynamically can create an array of that user control like this
    
    a global variable
       private UserControl1[] userControl11=new WindowsFormsApplication1.UserControl1[3];
    
    
    and now the array of user control
    you can write it on a button
    
    this.SuspendLayout();
                Random r=new Random(DateTime.Now.Millisecond);
                for (int i = 0; i < 3; i++)
                {
    
                    userControl11[i] = new UserControl1();
                    this.userControl11[i].formColor = Color.FromArgb(r.Next(255),r.Next(255),r.Next(255));
                    this.userControl11[i].Location = new System.Drawing.Point(133 , 133*(i+1));
                    this.userControl11[i].Name = "userControl11";
                    this.userControl11[i].Size = new System.Drawing.Size(278, 133);
                    this.userControl11[i].TabIndex = 0;
                    this.Controls.Add(this.userControl11[i]);
                }
                ;
