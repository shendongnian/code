    partial class FormMain
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bornDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.labelDataGridViewCountText = new System.Windows.Forms.Label();
            this.labelDataGridViewCount = new System.Windows.Forms.Label();
            this.labelSpinsBetweenInsertsText = new System.Windows.Forms.Label();
            this.numericUpDownTimeoutBetweenInserts = new System.Windows.Forms.NumericUpDown();
            this.checkBoxToggleWorker = new System.Windows.Forms.CheckBox();
            this.timerGuiUpdater = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeoutBetweenInserts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.lastNameDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.bornDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.personBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(560, 212);
            this.dataGridView.TabIndex = 0;
            // 
            // Index
            // 
            this.Index.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Index.DataPropertyName = "Index";
            this.Index.HeaderText = "Index";
            this.Index.Name = "Index";
            this.Index.Width = 58;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // bornDataGridViewTextBoxColumn
            // 
            this.bornDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.bornDataGridViewTextBoxColumn.DataPropertyName = "Born";
            this.bornDataGridViewTextBoxColumn.HeaderText = "Born";
            this.bornDataGridViewTextBoxColumn.Name = "bornDataGridViewTextBoxColumn";
            this.bornDataGridViewTextBoxColumn.Width = 54;
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            this.ageDataGridViewTextBoxColumn.ReadOnly = true;
            this.ageDataGridViewTextBoxColumn.Width = 51;
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataSource = typeof(WindowsFormsApplication.Person);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnBackgroundWorkerDoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnBackgroundWorkerRunWorkerCompleted);
            // 
            // labelDataGridViewCountText
            // 
            this.labelDataGridViewCountText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDataGridViewCountText.Location = new System.Drawing.Point(12, 230);
            this.labelDataGridViewCountText.Name = "labelDataGridViewCountText";
            this.labelDataGridViewCountText.Size = new System.Drawing.Size(50, 23);
            this.labelDataGridViewCountText.TabIndex = 1;
            this.labelDataGridViewCountText.Text = "Count:";
            this.labelDataGridViewCountText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDataGridViewCount
            // 
            this.labelDataGridViewCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDataGridViewCount.Location = new System.Drawing.Point(68, 230);
            this.labelDataGridViewCount.Name = "labelDataGridViewCount";
            this.labelDataGridViewCount.Size = new System.Drawing.Size(82, 23);
            this.labelDataGridViewCount.TabIndex = 2;
            this.labelDataGridViewCount.Text = "0";
            this.labelDataGridViewCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSpinsBetweenInsertsText
            // 
            this.labelSpinsBetweenInsertsText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpinsBetweenInsertsText.Location = new System.Drawing.Point(265, 230);
            this.labelSpinsBetweenInsertsText.Name = "labelSpinsBetweenInsertsText";
            this.labelSpinsBetweenInsertsText.Size = new System.Drawing.Size(155, 23);
            this.labelSpinsBetweenInsertsText.TabIndex = 3;
            this.labelSpinsBetweenInsertsText.Text = "Spins between inserts:";
            this.labelSpinsBetweenInsertsText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownTimeoutBetweenInserts
            // 
            this.numericUpDownTimeoutBetweenInserts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownTimeoutBetweenInserts.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTimeoutBetweenInserts.Location = new System.Drawing.Point(426, 233);
            this.numericUpDownTimeoutBetweenInserts.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownTimeoutBetweenInserts.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownTimeoutBetweenInserts.Name = "numericUpDownTimeoutBetweenInserts";
            this.numericUpDownTimeoutBetweenInserts.Size = new System.Drawing.Size(65, 20);
            this.numericUpDownTimeoutBetweenInserts.TabIndex = 4;
            this.numericUpDownTimeoutBetweenInserts.ThousandsSeparator = true;
            this.numericUpDownTimeoutBetweenInserts.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownTimeoutBetweenInserts.ValueChanged += new System.EventHandler(this.OnNumericUpDownTimeoutBetweenInsertsValueChanged);
            // 
            // checkBoxToggleWorker
            // 
            this.checkBoxToggleWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxToggleWorker.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxToggleWorker.Location = new System.Drawing.Point(497, 230);
            this.checkBoxToggleWorker.Name = "checkBoxToggleWorker";
            this.checkBoxToggleWorker.Size = new System.Drawing.Size(75, 23);
            this.checkBoxToggleWorker.TabIndex = 6;
            this.checkBoxToggleWorker.Text = "&Start";
            this.checkBoxToggleWorker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxToggleWorker.UseVisualStyleBackColor = true;
            this.checkBoxToggleWorker.CheckedChanged += new System.EventHandler(this.OnCheckBoxToggleWorkerCheckedChanged);
            // 
            // timerGuiUpdater
            // 
            this.timerGuiUpdater.Tick += new System.EventHandler(this.OnTimerGuiUpdaterTick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.checkBoxToggleWorker);
            this.Controls.Add(this.numericUpDownTimeoutBetweenInserts);
            this.Controls.Add(this.labelSpinsBetweenInsertsText);
            this.Controls.Add(this.labelDataGridViewCount);
            this.Controls.Add(this.labelDataGridViewCountText);
            this.Controls.Add(this.dataGridView);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "FormMain";
            this.Text = "DataGridView Performance Tester";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeoutBetweenInserts)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.BindingSource personBindingSource;
        private System.Windows.Forms.Label labelDataGridViewCountText;
        private System.Windows.Forms.Label labelDataGridViewCount;
        private System.Windows.Forms.Label labelSpinsBetweenInsertsText;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeoutBetweenInserts;
        private System.Windows.Forms.CheckBox checkBoxToggleWorker;
        private System.Windows.Forms.Timer timerGuiUpdater;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bornDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
    }
