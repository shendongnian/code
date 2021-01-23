            Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint2 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0R, 0.0R)
        Me.chart_slider = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        CType(Me.chart_slider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chart_slider
        '
        Me.chart_slider.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chart_slider.BackColor = System.Drawing.Color.Transparent
        ChartArea2.AxisX.LabelAutoFitMaxFontSize = 8
        ChartArea2.AxisX.LabelAutoFitMinFontSize = 8
        ChartArea2.AxisX.LineColor = System.Drawing.Color.Transparent
        ChartArea2.AxisX.MajorGrid.Enabled = False
        ChartArea2.AxisX.Maximum = 100.0R
        ChartArea2.AxisX.Minimum = 0.0R
        ChartArea2.AxisY.Interval = 1.0R
        ChartArea2.AxisY.LineWidth = 0
        ChartArea2.AxisY.MajorGrid.Enabled = False
        ChartArea2.AxisY.MajorTickMark.Enabled = False
        ChartArea2.AxisY.Maximum = 0.0R
        ChartArea2.AxisY.Minimum = 0.0R
        ChartArea2.AxisY.TitleForeColor = System.Drawing.Color.Transparent
        ChartArea2.BackColor = System.Drawing.Color.Transparent
        ChartArea2.Name = "ChartArea1"
        Me.chart_slider.ChartAreas.Add(ChartArea2)
        Legend2.Enabled = False
        Legend2.Name = "Legend1"
        Me.chart_slider.Legends.Add(Legend2)
        Me.chart_slider.Location = New System.Drawing.Point(186, 426)
        Me.chart_slider.Name = "chart_slider"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Series2.Points.Add(DataPoint2)
        Me.chart_slider.Series.Add(Series2)
        Me.chart_slider.Size = New System.Drawing.Size(441, 31)
        Me.chart_slider.TabIndex = 160
        Me.chart_slider.Text = "Chart1"
        '
        'TrackBar1
        '
        Me.TrackBar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackBar1.Location = New System.Drawing.Point(191, 398)
        Me.TrackBar1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.RightToLeftLayout = True
        Me.TrackBar1.Size = New System.Drawing.Size(423, 45)
        Me.TrackBar1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 498)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.chart_slider)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.chart_slider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
