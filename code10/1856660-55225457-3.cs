    partial class frmTLPTest1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.panToolbar = new System.Windows.Forms.Panel();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.chkRandom = new System.Windows.Forms.CheckBox();
            this.btnRemoveControl = new System.Windows.Forms.Button();
            this.btnAddControl = new System.Windows.Forms.Button();
            this.panBackground = new System.Windows.Forms.Panel();
            this.tlp1 = new System.Windows.Forms.TableLayoutPanel();
            this.panToolbar.SuspendLayout();
            this.panBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // panToolbar
            // 
            this.panToolbar.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.panToolbar.Controls.Add(this.btnRemoveRow);
            this.panToolbar.Controls.Add(this.chkRandom);
            this.panToolbar.Controls.Add(this.btnRemoveControl);
            this.panToolbar.Controls.Add(this.btnAddControl);
            this.panToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panToolbar.Location = new System.Drawing.Point(0, 359);
            this.panToolbar.Name = "panToolbar";
            this.panToolbar.Size = new System.Drawing.Size(552, 55);
            this.panToolbar.TabIndex = 2;
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnRemoveRow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRemoveRow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRemoveRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveRow.ForeColor = System.Drawing.Color.White;
            this.btnRemoveRow.Location = new System.Drawing.Point(261, 11);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(119, 34);
            this.btnRemoveRow.TabIndex = 4;
            this.btnRemoveRow.Text = "Remove Row";
            this.btnRemoveRow.UseVisualStyleBackColor = false;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // chkRandom
            // 
            this.chkRandom.AutoSize = true;
            this.chkRandom.ForeColor = System.Drawing.Color.White;
            this.chkRandom.Location = new System.Drawing.Point(446, 20);
            this.chkRandom.Name = "chkRandom";
            this.chkRandom.Size = new System.Drawing.Size(94, 19);
            this.chkRandom.TabIndex = 3;
            this.chkRandom.Text = "Random Size";
            this.chkRandom.UseVisualStyleBackColor = true;
            // 
            // btnRemoveControl
            // 
            this.btnRemoveControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnRemoveControl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRemoveControl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRemoveControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveControl.ForeColor = System.Drawing.Color.White;
            this.btnRemoveControl.Location = new System.Drawing.Point(136, 11);
            this.btnRemoveControl.Name = "btnRemoveControl";
            this.btnRemoveControl.Size = new System.Drawing.Size(119, 34);
            this.btnRemoveControl.TabIndex = 2;
            this.btnRemoveControl.Text = "Remove Control";
            this.btnRemoveControl.UseVisualStyleBackColor = false;
            this.btnRemoveControl.Click += new System.EventHandler(this.btnRemoveControl_Click);
            // 
            // btnAddControl
            // 
            this.btnAddControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnAddControl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddControl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddControl.ForeColor = System.Drawing.Color.White;
            this.btnAddControl.Location = new System.Drawing.Point(11, 11);
            this.btnAddControl.Name = "btnAddControl";
            this.btnAddControl.Size = new System.Drawing.Size(119, 34);
            this.btnAddControl.TabIndex = 0;
            this.btnAddControl.Text = "Add Control";
            this.btnAddControl.UseVisualStyleBackColor = false;
            this.btnAddControl.Click += new System.EventHandler(this.btnAddControl_Click);
            // 
            // panBackground
            // 
            this.panBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBackground.AutoScroll = true;
            this.panBackground.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panBackground.Controls.Add(this.tlp1);
            this.panBackground.Location = new System.Drawing.Point(0, 0);
            this.panBackground.Name = "panBackground";
            this.panBackground.Size = new System.Drawing.Size(552, 360);
            this.panBackground.TabIndex = 3;
            // 
            // tlp1
            // 
            this.tlp1.AutoSize = true;
            this.tlp1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlp1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tlp1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlp1.ColumnCount = 1;
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp1.Location = new System.Drawing.Point(0, 0);
            this.tlp1.Name = "tlp1";
            this.tlp1.RowCount = 1;
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlp1.Size = new System.Drawing.Size(552, 2);
            this.tlp1.TabIndex = 4;
            // 
            // frmTLPTest1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(552, 414);
            this.Controls.Add(this.panBackground);
            this.Controls.Add(this.panToolbar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmTLPTest1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTLPTest1";
            this.Load += new System.EventHandler(this.SOfrmTest1_Load);
            this.panToolbar.ResumeLayout(false);
            this.panToolbar.PerformLayout();
            this.panBackground.ResumeLayout(false);
            this.panBackground.PerformLayout();
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Panel panToolbar;
        private System.Windows.Forms.Button btnAddControl;
        private System.Windows.Forms.Button btnRemoveControl;
        private System.Windows.Forms.CheckBox chkRandom;
        private System.Windows.Forms.Panel panBackground;
        private System.Windows.Forms.TableLayoutPanel tlp1;
        private System.Windows.Forms.Button btnRemoveRow;
    }
