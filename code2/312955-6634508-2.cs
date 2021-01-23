    namespace XSLTTest
    {
    	partial class frmXSLTTest
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
    			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
    			this.btnTransform = new System.Windows.Forms.Button();
    			this.groupBox1 = new System.Windows.Forms.GroupBox();
    			this.txtStylesheet = new System.Windows.Forms.TextBox();
    			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
    			this.groupBox2 = new System.Windows.Forms.GroupBox();
    			this.txtInputXML = new System.Windows.Forms.TextBox();
    			this.groupBox3 = new System.Windows.Forms.GroupBox();
    			this.txtOutputXML = new System.Windows.Forms.TextBox();
    			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
    			this.splitContainer1.Panel1.SuspendLayout();
    			this.splitContainer1.Panel2.SuspendLayout();
    			this.splitContainer1.SuspendLayout();
    			this.groupBox1.SuspendLayout();
    			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
    			this.splitContainer2.Panel1.SuspendLayout();
    			this.splitContainer2.Panel2.SuspendLayout();
    			this.splitContainer2.SuspendLayout();
    			this.groupBox2.SuspendLayout();
    			this.groupBox3.SuspendLayout();
    			this.SuspendLayout();
    			// 
    			// splitContainer1
    			// 
    			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
    			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
    			this.splitContainer1.Name = "splitContainer1";
    			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
    			// 
    			// splitContainer1.Panel1
    			// 
    			this.splitContainer1.Panel1.Controls.Add(this.btnTransform);
    			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
    			// 
    			// splitContainer1.Panel2
    			// 
    			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
    			this.splitContainer1.Size = new System.Drawing.Size(788, 363);
    			this.splitContainer1.SplitterDistance = 194;
    			this.splitContainer1.TabIndex = 0;
    			// 
    			// btnTransform
    			// 
    			this.btnTransform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
    			this.btnTransform.Location = new System.Drawing.Point(6, 167);
    			this.btnTransform.Name = "btnTransform";
    			this.btnTransform.Size = new System.Drawing.Size(75, 23);
    			this.btnTransform.TabIndex = 1;
    			this.btnTransform.Text = "Transform";
    			this.btnTransform.UseVisualStyleBackColor = true;
    			this.btnTransform.Click += new System.EventHandler(this.btnTransform_Click);
    			// 
    			// groupBox1
    			// 
    			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
    			this.groupBox1.Controls.Add(this.txtStylesheet);
    			this.groupBox1.Location = new System.Drawing.Point(3, 3);
    			this.groupBox1.Name = "groupBox1";
    			this.groupBox1.Size = new System.Drawing.Size(782, 161);
    			this.groupBox1.TabIndex = 0;
    			this.groupBox1.TabStop = false;
    			this.groupBox1.Text = "Stylesheet";
    			// 
    			// txtStylesheet
    			// 
    			this.txtStylesheet.Dock = System.Windows.Forms.DockStyle.Fill;
    			this.txtStylesheet.Font = new System.Drawing.Font("Lucida Console", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    			this.txtStylesheet.Location = new System.Drawing.Point(3, 16);
    			this.txtStylesheet.MaxLength = 1000000;
    			this.txtStylesheet.Multiline = true;
    			this.txtStylesheet.Name = "txtStylesheet";
    			this.txtStylesheet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
    			this.txtStylesheet.Size = new System.Drawing.Size(776, 142);
    			this.txtStylesheet.TabIndex = 0;
    			// 
    			// splitContainer2
    			// 
    			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
    			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
    			this.splitContainer2.Name = "splitContainer2";
    			// 
    			// splitContainer2.Panel1
    			// 
    			this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
    			// 
    			// splitContainer2.Panel2
    			// 
    			this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
    			this.splitContainer2.Size = new System.Drawing.Size(788, 165);
    			this.splitContainer2.SplitterDistance = 395;
    			this.splitContainer2.TabIndex = 0;
    			// 
    			// groupBox2
    			// 
    			this.groupBox2.Controls.Add(this.txtInputXML);
    			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
    			this.groupBox2.Location = new System.Drawing.Point(0, 0);
    			this.groupBox2.Name = "groupBox2";
    			this.groupBox2.Size = new System.Drawing.Size(395, 165);
    			this.groupBox2.TabIndex = 1;
    			this.groupBox2.TabStop = false;
    			this.groupBox2.Text = "Input XML";
    			// 
    			// txtInputXML
    			// 
    			this.txtInputXML.Dock = System.Windows.Forms.DockStyle.Fill;
    			this.txtInputXML.Font = new System.Drawing.Font("Lucida Console", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    			this.txtInputXML.Location = new System.Drawing.Point(3, 16);
    			this.txtInputXML.MaxLength = 1000000;
    			this.txtInputXML.Multiline = true;
    			this.txtInputXML.Name = "txtInputXML";
    			this.txtInputXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
    			this.txtInputXML.Size = new System.Drawing.Size(389, 146);
    			this.txtInputXML.TabIndex = 1;
    			// 
    			// groupBox3
    			// 
    			this.groupBox3.Controls.Add(this.txtOutputXML);
    			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
    			this.groupBox3.Location = new System.Drawing.Point(0, 0);
    			this.groupBox3.Name = "groupBox3";
    			this.groupBox3.Size = new System.Drawing.Size(389, 165);
    			this.groupBox3.TabIndex = 1;
    			this.groupBox3.TabStop = false;
    			this.groupBox3.Text = "Output XML";
    			// 
    			// txtOutputXML
    			// 
    			this.txtOutputXML.Dock = System.Windows.Forms.DockStyle.Fill;
    			this.txtOutputXML.Font = new System.Drawing.Font("Lucida Console", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    			this.txtOutputXML.Location = new System.Drawing.Point(3, 16);
    			this.txtOutputXML.MaxLength = 1000000;
    			this.txtOutputXML.Multiline = true;
    			this.txtOutputXML.Name = "txtOutputXML";
    			this.txtOutputXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
    			this.txtOutputXML.Size = new System.Drawing.Size(383, 146);
    			this.txtOutputXML.TabIndex = 1;
    			// 
    			// frmXSLTTest
    			// 
    			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    			this.ClientSize = new System.Drawing.Size(788, 363);
    			this.Controls.Add(this.splitContainer1);
    			this.Name = "frmXSLTTest";
    			this.Text = "frmXSLTTest";
    			this.splitContainer1.Panel1.ResumeLayout(false);
    			this.splitContainer1.Panel2.ResumeLayout(false);
    			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
    			this.splitContainer1.ResumeLayout(false);
    			this.groupBox1.ResumeLayout(false);
    			this.groupBox1.PerformLayout();
    			this.splitContainer2.Panel1.ResumeLayout(false);
    			this.splitContainer2.Panel2.ResumeLayout(false);
    			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
    			this.splitContainer2.ResumeLayout(false);
    			this.groupBox2.ResumeLayout(false);
    			this.groupBox2.PerformLayout();
    			this.groupBox3.ResumeLayout(false);
    			this.groupBox3.PerformLayout();
    			this.ResumeLayout(false);
    
    		}
    
    		#endregion
    
    		private System.Windows.Forms.SplitContainer splitContainer1;
    		private System.Windows.Forms.Button btnTransform;
    		private System.Windows.Forms.GroupBox groupBox1;
    		private System.Windows.Forms.TextBox txtStylesheet;
    		private System.Windows.Forms.SplitContainer splitContainer2;
    		private System.Windows.Forms.GroupBox groupBox2;
    		private System.Windows.Forms.GroupBox groupBox3;
    		private System.Windows.Forms.TextBox txtInputXML;
    		private System.Windows.Forms.TextBox txtOutputXML;
    	}
    }
