    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using WIA;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
        public Form1()
        {
            InitializeComponent();
            this.button1.Text = "Select Camera";
            this.label1.Text = "[ no camera selected ]";
        }
        private void Form1_Load(object sender, EventArgs e) { }
        private String _label = null;
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
            // create a new WIA common dialog box for the user to select a device from
            WIA.CommonDialog dlg = new WIA.CommonDialog();
            // show user the WIA device dialog
            Device d = dlg.ShowSelectDevice(WiaDeviceType.CameraDeviceType, true, false);
            // check if a device was selected
            if (d != null)
            {
                // Print camera properties
                richTextBox1.AppendText("\n\n Print properties:\n");
                foreach (Property p in d.Properties)
                {
                richTextBox1.AppendText(p.Name + ": " + p.get_Value() + "  ("+ p.PropertyID + ":" + p.IsReadOnly + ") \n");
                // Update UI
                if (p.PropertyID == 3) _label = (String) p.get_Value();
                if (p.PropertyID == 4) _label = _label + " - " + p.get_Value();
                this.label1.Text = _label;
                }
                // Print commands
                richTextBox1.AppendText("\n\n Print commands:\n");
                foreach (DeviceCommand dvc in d.Commands)
                {
                richTextBox1.AppendText(dvc.Name + ": " + dvc.Description + "  ("+ dvc.CommandID +") \n");
                }
                // Print events
                richTextBox1.AppendText("\n\n Print events:\n");
                foreach (DeviceEvent dve in d.Events)
                {
                richTextBox1.AppendText(dve.Name + ": " + dve.Description + "  (" + dve.Type + ") \n");
                }
                // Print item properties
                richTextBox1.AppendText("\n\n Print item properties:\n");
                foreach (Property item in d.Items[1].Properties)
                {
                richTextBox1.AppendText(item.IsReadOnly + ": " + item.Name + "  (" + item.PropertyID + ") \n");
                }
                
                foreach (WIA.Property p in d.Properties)
                {
                Object tempNewProperty;
                // change Exposure Compensation: value 0 to 2 (ID 2053, isReadonly False)
                if (p.PropertyID == 2053)
                {
                    tempNewProperty = (int) -2000;  // can not be set to minus values, why???
                    ((IProperty)p).set_Value(ref tempNewProperty);
                    richTextBox1.AppendText(">>>>" + p.get_Value());
                }
                }
                
                // Now let's take a picture !
                d.ExecuteCommand(CommandID.wiaCommandTakePicture);
                richTextBox1.AppendText(".");
                
            }
            else
            {
                d = null;
                richTextBox1.AppendText("Result: no device selected or device could not be read. ");
            }
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message, "WIA Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
           
        }
    }
    namespace WindowsFormsApplication1
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
                this.label1 = new System.Windows.Forms.Label();
                this.richTextBox1 = new System.Windows.Forms.RichTextBox();
                this.button2 = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(12, 12);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(137, 23);
                this.button1.TabIndex = 0;
                this.button1.Text = "button1";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click_1);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(9, 44);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(35, 13);
                this.label1.TabIndex = 1;
                this.label1.Text = "label1";
                // 
                // richTextBox1
                // 
                this.richTextBox1.Location = new System.Drawing.Point(12, 60);
                this.richTextBox1.Name = "richTextBox1";
                this.richTextBox1.Size = new System.Drawing.Size(946, 445);
                this.richTextBox1.TabIndex = 2;
                this.richTextBox1.Text = "";
                // 
                // button2
                // 
                this.button2.Location = new System.Drawing.Point(156, 11);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(173, 23);
                this.button2.TabIndex = 3;
                this.button2.Text = "button2";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click_1);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(970, 517);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.richTextBox1);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.button1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Load += new System.EventHandler(this.Form1_Load);
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            #endregion
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.RichTextBox richTextBox1;
            private System.Windows.Forms.Button button2;
        }
    }
