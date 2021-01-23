    namespace MessageBoxWithDetails
    {
    	partial class MessageBoxWithDetails
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
	    		this.btnClose = new System.Windows.Forms.Button();
		    	this.btnDetails = new System.Windows.Forms.Button();
			    this.btnCopy = new System.Windows.Forms.Button();
    			this.lblMessage = new System.Windows.Forms.Label();
	    		this.tbDetails = new System.Windows.Forms.TextBox();
		    	this.SuspendLayout();
    			// 
	    		// btnClose
		    	// 
    			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
	    		this.btnClose.Location = new System.Drawing.Point(267, 37);
		    	this.btnClose.Name = "btnClose";
			    this.btnClose.Size = new System.Drawing.Size(75, 23);
    			this.btnClose.TabIndex = 0;
		    	this.btnClose.Text = "Close";
			    this.btnClose.UseVisualStyleBackColor = true;
    			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
	    		// 
		    	// btnDetails
			    // 
    			this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
		    	this.btnDetails.Enabled = false;
    			this.btnDetails.Location = new System.Drawing.Point(12, 37);
	    		this.btnDetails.Name = "btnDetails";
		    	this.btnDetails.Size = new System.Drawing.Size(75, 23);
			    this.btnDetails.TabIndex = 1;
    			this.btnDetails.Text = "Details";
	    		this.btnDetails.UseVisualStyleBackColor = true;
		    	this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
    			// 
	    		// btnCopy
		    	// 
			    this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
    			this.btnCopy.Location = new System.Drawing.Point(93, 37);
	    		this.btnCopy.Name = "btnCopy";
		    	this.btnCopy.Size = new System.Drawing.Size(102, 23);
			    this.btnCopy.TabIndex = 4;
    			this.btnCopy.Text = "Copy To Clipboard";
	    		this.btnCopy.UseVisualStyleBackColor = true;
		    	this.btnCopy.Visible = false;
    			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
	    		// 
		    	// lblMessage
			    // 
    			this.lblMessage.AutoSize = true;
	    		this.lblMessage.Location = new System.Drawing.Point(12, 9);
		    	this.lblMessage.MaximumSize = new System.Drawing.Size(310, 0);
			    this.lblMessage.Name = "lblMessage";
    			this.lblMessage.Size = new System.Drawing.Size(35, 13);
	    		this.lblMessage.TabIndex = 5;
		    	this.lblMessage.Text = "label1";
			    // 
    			// tbDetails
	    		// 
		    	this.tbDetails.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
    			this.tbDetails.Location = new System.Drawing.Point(12, 68);
	    		this.tbDetails.MaximumSize = new System.Drawing.Size(328, 100);
		    	this.tbDetails.Multiline = true;
			    this.tbDetails.Name = "tbDetails";
    			this.tbDetails.ReadOnly = true;
	    		this.tbDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
    			this.tbDetails.Size = new System.Drawing.Size(328, 100);
	    		this.tbDetails.TabIndex = 6;
		    	this.tbDetails.Visible = false;
			    // 
    			// MessageBoxWithDetails
	    		// 
		    	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    			this.ClientSize = new System.Drawing.Size(354, 72);
	    		this.Controls.Add(this.tbDetails);
		    	this.Controls.Add(this.lblMessage);
			    this.Controls.Add(this.btnCopy);
    			this.Controls.Add(this.btnDetails);
	    		this.Controls.Add(this.btnClose);
		    	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
    			this.MaximizeBox = false;
	    		this.MinimizeBox = false;
		    	this.Name = "MessageBoxWithDetails";
			    this.ShowIcon = false;
    			this.ShowInTaskbar = false;
	    		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    			this.ResumeLayout(false);
	    		this.PerformLayout();
    
	    	}
		    #endregion
    		private System.Windows.Forms.Button btnClose;
	    	private System.Windows.Forms.Button btnDetails;
		    private System.Windows.Forms.Button btnCopy;
    		private System.Windows.Forms.Label lblMessage;
	    	private System.Windows.Forms.TextBox tbDetails;
    	}
    }
