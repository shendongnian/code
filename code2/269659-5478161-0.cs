    namespace PathFinder
    {
       Map map1;
     BackgroundWorker GetSomeData = new BackgroundWorker();
    
       public Form1()
       {
          GetSomeData .DoWork += new DoWorkEventHandler(GetSomeData_DoWork);
          map1 = new Map(tileDimension, mapDimension);
          GetSomeData.RunWorkerAsync();
          this.Invalidate();
       }
     void GetSomeData_DoWork(object sender, DoWorkEventArgs e)
     {
          map1.Generate(); //the function that calculate the path
     }
            
       private void Form1_Paint(object sender, PaintEventArgs e)
       {
          //drawings
          this.Invalidate();
       }
    }
