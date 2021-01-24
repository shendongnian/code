    SizeF scalingFactor;
    public Form1()
    {
        InitializeComponent();
    
        SuspendLayout();
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        AutoScaleDimensions = new System.Drawing.SizeF(8.0F, 16.0F);
    
        // at this point you can obtain the scaling factor that will
        // be applied on ResumeLayout
        scalingFactor = AutoScaleFactor;
    
        // store the design-time bounds in the control's Tag property
        RecursivelyRecordBounds(this);
        ResumeLayout(true);
    }
