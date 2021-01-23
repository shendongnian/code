    protected void Portrait()
    {
       this.SuspendLayout();
       this.crawlTime.Location = new System.Drawing.Point(88, 216);
       this.crawlTime.Size = new System.Drawing.Size(136, 16);
       this.crawlTimeLabel.Location = new System.Drawing.Point(10, 216);
       this.crawlTimeLabel.Size = new System.Drawing.Size(64, 16);
       this.crawlStartTime.Location = new System.Drawing.Point(88, 200);
       this.crawlStartTime.Size = new System.Drawing.Size(136, 16);
       this.crawlStartedLabel.Location = new System.Drawing.Point(10, 200);
       this.crawlStartedLabel.Size = new System.Drawing.Size(64, 16);
       this.light1.Location = new System.Drawing.Point(208, 66);
       this.light1.Size = new System.Drawing.Size(16, 16);
       this.light0.Location = new System.Drawing.Point(192, 66);
       this.light0.Size = new System.Drawing.Size(16, 16);
       this.linkCount.Location = new System.Drawing.Point(88, 182);
       this.linkCount.Size = new System.Drawing.Size(136, 16);
       this.linkCountLabel.Location = new System.Drawing.Point(10, 182);
       this.linkCountLabel.Size = new System.Drawing.Size(64, 16);
       this.currentPageBox.Location = new System.Drawing.Point(10, 84);
       this.currentPageBox.Size = new System.Drawing.Size(214, 90);
       this.currentPageLabel.Location = new System.Drawing.Point(10, 68);
       this.currentPageLabel.Size = new System.Drawing.Size(100, 16);
       this.addressLabel.Location = new System.Drawing.Point(10, 4);
       this.addressLabel.Size = new System.Drawing.Size(214, 16);
       this.noProxyCheck.Location = new System.Drawing.Point(10, 48);
       this.noProxyCheck.Size = new System.Drawing.Size(214, 20);
       this.startButton.Location = new System.Drawing.Point(8, 240);
       this.startButton.Size = new System.Drawing.Size(216, 20);
       this.addressBox.Location = new System.Drawing.Point(10, 24);
       this.addressBox.Size = new System.Drawing.Size(214, 22);
    
       //note! USING JUST AUTOSCALEMODE WILL NOT SOLVE ISSUE. MUST USE BOTH!
       this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F); //IMPORTANT
       this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;   //IMPORTANT
       this.ResumeLayout(false);
    }
    
    protected void Landscape()
    {
       this.SuspendLayout();
       this.crawlTime.Location = new System.Drawing.Point(216, 136);
       this.crawlTime.Size = new System.Drawing.Size(96, 16);
       this.crawlTimeLabel.Location = new System.Drawing.Point(160, 136);
       this.crawlTimeLabel.Size = new System.Drawing.Size(48, 16);
       this.crawlStartTime.Location = new System.Drawing.Point(64, 120);
       this.crawlStartTime.Size = new System.Drawing.Size(248, 16);
       this.crawlStartedLabel.Location = new System.Drawing.Point(8, 120);
       this.crawlStartedLabel.Size = new System.Drawing.Size(48, 16);
       this.light1.Location = new System.Drawing.Point(296, 48);
       this.light1.Size = new System.Drawing.Size(16, 16);
       this.light0.Location = new System.Drawing.Point(280, 48);
       this.light0.Size = new System.Drawing.Size(16, 16);
       this.linkCount.Location = new System.Drawing.Point(80, 136);
       this.linkCount.Size = new System.Drawing.Size(72, 16);
       this.linkCountLabel.Location = new System.Drawing.Point(8, 136);
       this.linkCountLabel.Size = new System.Drawing.Size(64, 16);
       this.currentPageBox.Location = new System.Drawing.Point(10, 64);
       this.currentPageBox.Size = new System.Drawing.Size(302, 48);
       this.currentPageLabel.Location = new System.Drawing.Point(10, 48);
       this.currentPageLabel.Size = new System.Drawing.Size(100, 16);
       this.addressLabel.Location = new System.Drawing.Point(10, 4);
       this.addressLabel.Size = new System.Drawing.Size(50, 16);
       this.noProxyCheck.Location = new System.Drawing.Point(168, 16);
       this.noProxyCheck.Size = new System.Drawing.Size(152, 24);
       this.startButton.Location = new System.Drawing.Point(8, 160);
       this.startButton.Size = new System.Drawing.Size(304, 20);
       this.addressBox.Location = new System.Drawing.Point(10, 20);
       this.addressBox.Size = new System.Drawing.Size(150, 22);
    
       //note! USING JUST AUTOSCALEMODE WILL NOT SOLVE ISSUE. MUST USE BOTH!
       this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F); //IMPORTANT
       this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;   //IMPORTANT
       this.ResumeLayout(false);
    }
