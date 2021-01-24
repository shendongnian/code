    namespace UltraGrid
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
    
            private void InitializeComponent()
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement1 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
                Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement2 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
                Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement3 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
                Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement4 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
                Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement5 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
                Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement6 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
                Infragistics.UltraChart.Resources.Appearance.LineChartAppearance lineChartAppearance1 = new Infragistics.UltraChart.Resources.Appearance.LineChartAppearance();
                Infragistics.UltraChart.Resources.Appearance.LineAppearance lineAppearance1 = new Infragistics.UltraChart.Resources.Appearance.LineAppearance() { Thickness = 3 };
                Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement7 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
                Infragistics.UltraChart.Resources.Appearance.LineAppearance lineAppearance2 = new Infragistics.UltraChart.Resources.Appearance.LineAppearance() { Thickness = 3 };
                Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement8 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
                Infragistics.UltraChart.Resources.Appearance.LineAppearance lineAppearance3 = new Infragistics.UltraChart.Resources.Appearance.LineAppearance() { Thickness = 3 };
                Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement9 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
                this.ultraChart1 = new Infragistics.Win.UltraWinChart.UltraChart();
                ((System.ComponentModel.ISupportInitialize)(this.ultraChart1)).BeginInit();
                this.SuspendLayout();
                this.ultraChart1.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.LineChart;
                // 
                // ultraChart1
                // 
                resources.ApplyResources(this.ultraChart1, "ultraChart1");
                this.ultraChart1.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
                paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
                paintElement1.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
                this.ultraChart1.Axis.PE = paintElement1;
                this.ultraChart1.Axis.X.Labels.Font = new System.Drawing.Font("Verdana", 7F);
                this.ultraChart1.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
                this.ultraChart1.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>";
                this.ultraChart1.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
                this.ultraChart1.Axis.X.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
                this.ultraChart1.Axis.X.Labels.SeriesLabels.FormatString = "";
                this.ultraChart1.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
                this.ultraChart1.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
                this.ultraChart1.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
                this.ultraChart1.Axis.X.Labels.SeriesLabels.Visible = true;
                this.ultraChart1.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
                this.ultraChart1.Axis.X.Labels.Visible = true;
                this.ultraChart1.Axis.X.LineThickness = 1;
                this.ultraChart1.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
                this.ultraChart1.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
                this.ultraChart1.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
                this.ultraChart1.Axis.X.MajorGridLines.Visible = true;
                this.ultraChart1.Axis.X.MinorGridLines.AlphaLevel = ((byte)(255));
                this.ultraChart1.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
                this.ultraChart1.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
                this.ultraChart1.Axis.X.MinorGridLines.Visible = false;
                this.ultraChart1.Axis.X.Visible = true;
                this.ultraChart1.Axis.X2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
                this.ultraChart1.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
                this.ultraChart1.Axis.X2.Labels.ItemFormatString = "<ITEM_LABEL>";
                this.ultraChart1.Axis.X2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
                this.ultraChart1.Axis.X2.Labels.SeriesLabels.FormatString = "";
                this.ultraChart1.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
                this.ultraChart1.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
                this.ultraChart1.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
                this.ultraChart1.Axis.X2.Labels.SeriesLabels.Visible = true;
                this.ultraChart1.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
                this.ultraChart1.Axis.X2.Labels.Visible = false;
                this.ultraChart1.Axis.X2.MajorGridLines.AlphaLevel = ((byte)(255));
                this.ultraChart1.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
                this.ultraChart1.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
                this.ultraChart1.Axis.X2.MajorGridLines.Visible = true;
                this.ultraChart1.Axis.X2.MinorGridLines.AlphaLevel = ((byte)(255));
                this.ultraChart1.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray;
                this.ultraChart1.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
                this.ultraChart1.Axis.X2.MinorGridLines.Visible = false;
                this.ultraChart1.Axis.X2.Visible = false;
                this.ultraChart1.Axis.Y.Extent = 110;
                this.ultraChart1.Axis.Y.Labels.Font = new System.Drawing.Font("Verdana", 7F);
                this.ultraChart1.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
                this.ultraChart1.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
                this.ultraChart1.Axis.Y.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                this.ultraChart1.Axis.Y.Labels.SeriesLabels.FormatString = "";
                this.ultraChart1.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
                this.ultraChart1.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                this.ultraChart1.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
                this.ultraChart1.Axis.Y.Labels.SeriesLabels.Visible = true;
                this.ultraChart1.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
                this.ultraChart1.Axis.Y.Labels.Visible = true;
                this.ultraChart1.Axis.Y.LineThickness = 1;
                this.ultraChart1.Axis.Y.MajorGridLines.AlphaLevel = ((byte)(255));
                this.ultraChart1.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
                this.ultraChart1.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
                this.ultraChart1.Axis.Y.MajorGridLines.Visible = true;
                this.ultraChart1.Axis.Y.MinorGridLines.AlphaLevel = ((byte)(255));
                this.ultraChart1.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
                this.ultraChart1.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
                this.ultraChart1.Axis.Y.MinorGridLines.Visible = false;
                this.ultraChart1.Axis.Y.TickmarkInterval = 50D;
                this.ultraChart1.Axis.Y.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
                this.ultraChart1.Axis.Y.Visible = true;
                this.ultraChart1.Axis.Y2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
                this.ultraChart1.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
                this.ultraChart1.Axis.Y2.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
                this.ultraChart1.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                this.ultraChart1.Axis.Y2.Labels.SeriesLabels.FormatString = "";
                this.ultraChart1.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
                this.ultraChart1.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                this.ultraChart1.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
                this.ultraChart1.Axis.Y2.Labels.SeriesLabels.Visible = true;
                this.ultraChart1.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
                this.ultraChart1.Axis.Y2.Labels.Visible = false;
                this.ultraChart1.Axis.Y2.MajorGridLines.AlphaLevel = ((byte)(255));
                this.ultraChart1.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
                this.ultraChart1.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
                this.ultraChart1.Axis.Y2.MajorGridLines.Visible = true;
                this.ultraChart1.Axis.Y2.MinorGridLines.AlphaLevel = ((byte)(255));
                this.ultraChart1.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray;
                this.ultraChart1.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
                this.ultraChart1.Axis.Y2.MinorGridLines.Visible = false;
                this.ultraChart1.Axis.Y2.Visible = false;
                this.ultraChart1.Axis.Z.Labels.Font = new System.Drawing.Font("Verdana", 7F);
                this.ultraChart1.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
                this.ultraChart1.Axis.Z.Labels.ItemFormatString = "";
                this.ultraChart1.Axis.Z.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                this.ultraChart1.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
                this.ultraChart1.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                this.ultraChart1.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
                this.ultraChart1.Axis.Z.Labels.SeriesLabels.Visible = true;
                this.ultraChart1.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
                this.ultraChart1.Axis.Z.Labels.Visible = true;
                this.ultraChart1.Axis.Z.MajorGridLines.AlphaLevel = ((byte)(255));
                this.ultraChart1.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
                this.ultraChart1.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
                this.ultraChart1.Axis.Z.MajorGridLines.Visible = true;
                this.ultraChart1.Axis.Z.MinorGridLines.AlphaLevel = ((byte)(255));
                this.ultraChart1.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray;
                this.ultraChart1.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
                this.ultraChart1.Axis.Z.MinorGridLines.Visible = false;
                this.ultraChart1.Axis.Z.Visible = false;
                this.ultraChart1.Axis.Z2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
                this.ultraChart1.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
                this.ultraChart1.Axis.Z2.Labels.ItemFormatString = "";
                this.ultraChart1.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                this.ultraChart1.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
                this.ultraChart1.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                this.ultraChart1.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
                this.ultraChart1.Axis.Z2.Labels.SeriesLabels.Visible = true;
                this.ultraChart1.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
                this.ultraChart1.Axis.Z2.Labels.Visible = false;
                this.ultraChart1.Axis.Z2.MajorGridLines.AlphaLevel = ((byte)(255));
                this.ultraChart1.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
                this.ultraChart1.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
                this.ultraChart1.Axis.Z2.MajorGridLines.Visible = true;
                this.ultraChart1.Axis.Z2.MinorGridLines.AlphaLevel = ((byte)(255));
                this.ultraChart1.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray;
                this.ultraChart1.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
                this.ultraChart1.Axis.Z2.MinorGridLines.Visible = false;
                this.ultraChart1.Axis.Z2.Visible = false;
                this.ultraChart1.Border.CornerRadius = 5;
                this.ultraChart1.ColorModel.AlphaLevel = ((byte)(150));
                this.ultraChart1.ColorModel.ModelStyle = Infragistics.UltraChart.Shared.Styles.ColorModels.CustomLinear;
                paintElement2.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.Gradient;
                paintElement2.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(162)))), ((int)(((byte)(36)))));
                paintElement2.FillGradientStyle = Infragistics.UltraChart.Shared.Styles.GradientStyle.Horizontal;
                paintElement2.FillStopColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(244)))), ((int)(((byte)(17)))));
                paintElement2.Stroke = System.Drawing.Color.Transparent;
                paintElement3.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.Gradient;
                paintElement3.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(108)))), ((int)(((byte)(176)))));
                paintElement3.FillGradientStyle = Infragistics.UltraChart.Shared.Styles.GradientStyle.Horizontal;
                paintElement3.FillStopColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
                paintElement3.Stroke = System.Drawing.Color.Transparent;
                paintElement4.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.Gradient;
                paintElement4.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))));
                paintElement4.FillGradientStyle = Infragistics.UltraChart.Shared.Styles.GradientStyle.Horizontal;
                paintElement4.FillStopColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(117)))), ((int)(((byte)(16)))));
                paintElement4.Stroke = System.Drawing.Color.Transparent;
                paintElement5.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.Gradient;
                paintElement5.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(190)))), ((int)(((byte)(2)))));
                paintElement5.FillGradientStyle = Infragistics.UltraChart.Shared.Styles.GradientStyle.Horizontal;
                paintElement5.FillStopColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(81)))));
                paintElement5.Stroke = System.Drawing.Color.Transparent;
                paintElement6.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.Gradient;
                paintElement6.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(122)))), ((int)(((byte)(10)))));
                paintElement6.FillGradientStyle = Infragistics.UltraChart.Shared.Styles.GradientStyle.Horizontal;
                paintElement6.FillStopColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(66)))));
                paintElement6.Stroke = System.Drawing.Color.Transparent;
                this.ultraChart1.ColorModel.Skin.PEs.AddRange(new Infragistics.UltraChart.Resources.Appearance.PaintElement[] {
                paintElement2,
                paintElement3,
                paintElement4,
                paintElement5,
                paintElement6});
                this.ultraChart1.Data.EmptyStyle.LineStyle.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dash;
                this.ultraChart1.Data.SwapRowsAndColumns = true;
                this.ultraChart1.ForeColor = System.Drawing.SystemColors.ControlText;
                this.ultraChart1.Legend.Font = new System.Drawing.Font("Verdana", 7F);
                this.ultraChart1.Legend.Location = Infragistics.UltraChart.Shared.Styles.LegendLocation.Top;
                this.ultraChart1.Legend.Visible = true;
                lineAppearance1.IconAppearance.CharacterFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
                paintElement7.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
                lineAppearance1.IconAppearance.PE = paintElement7;
                lineAppearance1.Key = "Monday";
                paintElement8.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
                lineAppearance2.IconAppearance.PE = paintElement8;
                lineAppearance2.Key = "Tuesday";
                lineAppearance2.LineStyle.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dash;
                paintElement9.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
                lineAppearance3.IconAppearance.PE = paintElement9;
                lineAppearance3.Key = "Wednesday";
                lineAppearance3.LineStyle.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
                lineChartAppearance1.LineAppearances.Add(lineAppearance1);
                lineChartAppearance1.LineAppearances.Add(lineAppearance2);
                lineChartAppearance1.LineAppearances.Add(lineAppearance3);
                this.ultraChart1.LineChart = lineChartAppearance1;
                this.ultraChart1.Name = "ultraChart1";
                this.ultraChart1.Tooltips.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
                this.ultraChart1.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray;
                this.ultraChart1.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray;
                // 
                // Form1
                // 
                this.BackColor = System.Drawing.Color.White;
                resources.ApplyResources(this, "$this");
                this.Controls.Add(this.ultraChart1);
                this.Name = "Form1";
                this.Load += new System.EventHandler(this.LineChartStyles_Load);
                ((System.ComponentModel.ISupportInitialize)(this.ultraChart1)).EndInit();
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
          private Infragistics.Win.UltraWinChart.UltraChart ultraChart1;
        }
    }
