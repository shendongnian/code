    public partial class Main : Form
    {
      private double percentage1;
      private double percentage2;
      private double percentage3;
      private double percentage4;
      private double percentage5;
      private double Percentage1 
      {
        get
        {
          return this.percentage1;
        }
        set
        {
          this.percentage1 = value;
          this.UpdatePercentageAll();  // this will update overall progress whenever the first one changes
          progressBar1.Value = GetValueFromPercentage(value);
        }
      }
      private double Percentage2
      // same code as for Percentage1
      void UpdatePercentageAll()
      {
        this.PercentageAll = (this.Percentage1 + this.Percentage2 + this.Percentage3 + this.Percentage4 + this.Percentage5) / 5;
      }
      static int GetValueFromPercentage(double percentage)
      {
        return (int)Math.Truncate(percentage);
      }
      double percentageAll;
      private double PercentageAll
      {
        get
        {
          return this.percentageAll;
        }
        set
        {
          this.percentageAll = value;
          progressBarAll.Value = GetValueFromPercentage(value);
        }
      }
      //Download File Async custom method
      public void DldFile(string url, string fileName, string localPath, AsyncCompletedEventHandler completedName, DownloadProgressChangedEventHandler progressName)
      {
        WebClient webClient = new WebClient();
        webClient.DownloadFileAsync(new Uri(url), localPath + "\\" + fileName);
        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(completedName);
        webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(progressName);
      }
      //Button 1 click event to start download
      private void btnDld1_Click(object sender, EventArgs e)
      {
        if (url1 != "" && Directory.Exists(localPath1))
        {
            this.StartDownloadFile1();
        }
        //took out the try/catch, other ifs to try and cut it down
      }
      void StartDownloadFile1()
      {
            this.Percentage1 = 0;
            _startDate1 = DateTime.Now;
            DldFile(url1, fileName1, localPath1, completed1, progress1);
      }
      //Download Progress Changed event for Download 1
      public void progress1(object sender, DownloadProgressChangedEventArgs e)
      {
        this.Percentage1 = e.ProgressPercentage; // update property, not field
        //this will be done in property setters
        //progressBar1.Value = int.Parse(Math.Truncate(percentage1).ToString());
      }
      // then add similar code for other download buttons
      //Button that starts all downloads click event where all my problems are at the moment
      private void btnDldAll_Click(object sender, EventArgs e)
      {
        //Checks if the link exists and starts it from the download button click event
        if (url1 != "")
        {
            this.StartDownloadFile1();
        }
        //Continues for url2, 3, 4, 5 and else
      }
    }
