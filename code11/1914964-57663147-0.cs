    this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
    this.labelDate = new System.Windows.Forms.Label();
    this.labelTime = new System.Windows.Forms.Label();
    this.tableLayout.SuspendLayout();
    this.SuspendLayout();
    // 
    // tableLayout
    // 
    this.tableLayout.ColumnCount = 1;
    this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
    this.tableLayout.Controls.Add(this.labelDate, 0, 0);
    this.tableLayout.Controls.Add(this.labelTime, 0, 1);
    this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
    this.tableLayout.Location = new System.Drawing.Point(0, 0);
    this.tableLayout.Name = "tableLayout";
    this.tableLayout.RowCount = 3;
    this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
    this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
    this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
    this.tableLayout.Size = new System.Drawing.Size(800, 450);
    this.tableLayout.TabIndex = 0;
    // 
    // labelDate
    // 
    this.labelDate.AutoSize = true;
    this.labelDate.Dock = System.Windows.Forms.DockStyle.Right;
    this.labelDate.Location = new System.Drawing.Point(742, 0);
    this.labelDate.Name = "labelDate";
    this.labelDate.Size = new System.Drawing.Size(55, 24);
    this.labelDate.TabIndex = 0;
    this.labelDate.Text = "26-8-2019";
    // 
    // labelTime
    // 
    this.labelTime.AutoSize = true;
    this.labelTime.Dock = System.Windows.Forms.DockStyle.Right;
    this.labelTime.Location = new System.Drawing.Point(748, 24);
    this.labelTime.Name = "labelTime";
    this.labelTime.Size = new System.Drawing.Size(49, 24);
    this.labelTime.TabIndex = 1;
    this.labelTime.Text = "19:59:58";
