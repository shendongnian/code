    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Globalization;
    using System.Threading;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private System.Windows.Forms.CheckBox chkShowWeeksNumbers;
            private System.Windows.Forms.CheckBox chkThisFormTopMost;
            private System.Windows.Forms.MaskedTextBox maskedInputBox;
            private System.Windows.Forms.Button btnShowFloatingCalendar;
    
            public Form1()
            {
                this.chkShowWeeksNumbers = new System.Windows.Forms.CheckBox();
                this.chkThisFormTopMost = new System.Windows.Forms.CheckBox();
                this.maskedInputBox = new System.Windows.Forms.MaskedTextBox();
                this.btnShowFloatingCalendar = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // chkShowNumbersOfWeeks
                // 
                this.chkShowWeeksNumbers.AutoSize = true;
                this.chkShowWeeksNumbers.Location = new System.Drawing.Point(18, 116);
                this.chkShowWeeksNumbers.Name = "chkShowWeeksNumbers";
                this.chkShowWeeksNumbers.Size = new System.Drawing.Size(137, 17);
                this.chkShowWeeksNumbers.TabIndex = 1;
                this.chkShowWeeksNumbers.Text = "Show number of weeks";
                this.chkShowWeeksNumbers.UseVisualStyleBackColor = true;
                // 
                // chkThisFormTopMost
                // 
                this.chkThisFormTopMost.AutoSize = true;
                this.chkThisFormTopMost.Location = new System.Drawing.Point(18, 139);
                this.chkThisFormTopMost.Name = "chkThisFormTopMost";
                this.chkThisFormTopMost.Size = new System.Drawing.Size(124, 17);
                this.chkThisFormTopMost.TabIndex = 2;
                this.chkThisFormTopMost.Text = "This form TopMost";
                this.chkThisFormTopMost.UseVisualStyleBackColor = true;
                this.chkThisFormTopMost.CheckedChanged += new EventHandler(chkThisFormTopMost_CheckedChanged);
                // 
                // maskedInputBox
                // 
                this.maskedInputBox.Location = new System.Drawing.Point(18, 53);
                this.maskedInputBox.Mask = "00/00/0000 00:00";
                this.maskedInputBox.Name = "maskedInputBox";
                this.maskedInputBox.Size = new System.Drawing.Size(115, 20);
                this.maskedInputBox.TabIndex = 3;
                this.maskedInputBox.ValidatingType = typeof(System.DateTime);
                // 
                // btnShowFloatingCalendar
                // 
                this.btnShowFloatingCalendar.Location = new System.Drawing.Point(139, 49);
                this.btnShowFloatingCalendar.Name = "btnShowFloatingCalendar";
                this.btnShowFloatingCalendar.Size = new System.Drawing.Size(65, 27);
                this.btnShowFloatingCalendar.TabIndex = 4;
                this.btnShowFloatingCalendar.Text = "Calendar";
                this.btnShowFloatingCalendar.UseVisualStyleBackColor = true;
                this.btnShowFloatingCalendar.Click += new EventHandler(btnShowFloatingCalendar_Click);
    
                // 
                // Form1
                // 
                this.Controls.Add(this.btnShowFloatingCalendar);
                this.Controls.Add(this.maskedInputBox);
                this.Controls.Add(this.chkThisFormTopMost);
                this.Controls.Add(this.chkShowWeeksNumbers);
    
                InitializeComponent();
            }
            
            private void Form1_Load(object sender, EventArgs e)
            {
                //DateTime format using in United States
                //More info: http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo%28v=vs.71%29.aspx
                //           http://msdn.microsoft.com/en-us/library/5hh873ya.aspx
                
                Thread.CurrentThread.CurrentCulture = new CultureInfo(0x0409);
    
                CultureInfo cultureInfoUSA = new CultureInfo(0x0409, false);
                this.maskedInputBox.Culture = cultureInfoUSA;
            }
    
            //Constructor
            clsMonthCalendarBehavior userCalendar = new clsMonthCalendarBehavior();
    
            private void btnShowFloatingCalendar_Click(object sender, EventArgs e)
            {           
                userCalendar.ShowCalendar(this.maskedInputBox,
                                          this.chkShowWeeksNumbers.Checked,
                                          this.chkThisFormTopMost.Checked);
            }
    
            private void chkThisFormTopMost_CheckedChanged(object sender, EventArgs e)
            {
                this.TopMost = this.chkThisFormTopMost.Checked;
            }
        }
    }
