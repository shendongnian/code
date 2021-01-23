    namespace TestDataGridView
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
                this.components = new System.ComponentModel.Container();
                this.dataGridView1 = new System.Windows.Forms.DataGridView();
                this.bindingSourceBindID = new System.Windows.Forms.BindingSource(this.components);
                this.bindingSourceA = new System.Windows.Forms.BindingSource(this.components);
                this.bindingSourceB = new System.Windows.Forms.BindingSource(this.components);
                this.ColumnA = new System.Windows.Forms.DataGridViewComboBoxColumn();
                this.ColumnB = new System.Windows.Forms.DataGridViewComboBoxColumn();
                ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBindID)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.bindingSourceA)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.bindingSourceB)).BeginInit();
                this.SuspendLayout();
                // 
                // dataGridView1
                // 
                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ColumnA,
                this.ColumnB});
                this.dataGridView1.DataSource = this.bindingSourceBindID;
                this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dataGridView1.Location = new System.Drawing.Point(0, 0);
                this.dataGridView1.Name = "dataGridView1";
                this.dataGridView1.Size = new System.Drawing.Size(709, 407);
                this.dataGridView1.TabIndex = 0;
                // 
                // ColumnA
                // 
                this.ColumnA.DataPropertyName = "AID";
                this.ColumnA.DataSource = this.bindingSourceA;
                this.ColumnA.HeaderText = "ColumnA";
                this.ColumnA.Name = "ColumnA";
                // 
                // ColumnB
                // 
                this.ColumnB.DataPropertyName = "BID";
                this.ColumnB.DataSource = this.bindingSourceB;
                this.ColumnB.HeaderText = "ColumnB";
                this.ColumnB.Name = "ColumnB";
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(709, 407);
                this.Controls.Add(this.dataGridView1);
                this.Name = "Form1";
                this.Text = "Form1";
                ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBindID)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.bindingSourceA)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.bindingSourceB)).EndInit();
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            private System.Windows.Forms.DataGridView dataGridView1;
            private System.Windows.Forms.BindingSource bindingSourceBindID;
            private System.Windows.Forms.BindingSource bindingSourceA;
            private System.Windows.Forms.BindingSource bindingSourceB;
            private System.Windows.Forms.DataGridViewComboBoxColumn ColumnA;
            private System.Windows.Forms.DataGridViewComboBoxColumn ColumnB;
        }
    }
