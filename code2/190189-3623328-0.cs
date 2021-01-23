    BackgroundWorker worker = new BackgroundWorker();
    void SomeForm_Load(object sender, EventArgs e)
    {
      // setup the BackgroundWorker 
      worker.WorkerReportsProgress = true;
      worker.DoWork += new DoWorkEventHandler(worker_DoWork);
      worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
      worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_Completed);
    }
 
    void SomeControl_Click(object sender, EventArgs e)
      List<Category> categories = DataBase.GetSomeCategories(); // [1] get Category list
      // start the BackgroundWorker passing in the categories list.
      worker.RunWorkerAsync(categories);
    }
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
      int progress = 0;
      var categories = e.Argument as List<Category>;       
      categories.ForEach(category =>                         // [2] process each Category
      {
        ThirdPartyControl.DoSomeProcessing(category);        // [2.a]
        var categoryPrice = CalculateCategoryPrice(category);
        var products = GetListOfProducts(category);          // [2.b] 
        products.ForEach(product =>                          // [2.c] process each Product
        {          
          var productPrice = CalcProductPrice(categoryPrice); 
          DataBase.UpdateProduct(product, productPrice);     // [2.d]
          progress = //...calculate progress...
          worker.ReportProgress(progress);                   // [3]
        });
        progress = //...calculate progress...
        worker.ReportProgress(progress);                     // [3]
      });
      worker.ReportProgress(100);
    }
    void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      //...update some UI stuff...
      progressBar.Value = e.ProgressPercentage;
    }
    void worker_Completed(object sender, RunWorkerCompletedEventArgs e)
    {
      //...all done...
    }
