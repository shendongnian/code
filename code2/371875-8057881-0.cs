        public partial class MyWindow : Window {
     
    
        delegate void TitleSetter(string title);
    
        public MyWindow() {
                InitializeComponent();
    
            var bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }
    
        void SetTitle(string T)
        {
          this.Title = T;
        }
    
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
        
          try    
            {
            TitleSetter T = new TitleSetter(SetTitle);
            invoke(T, new object[]{"Whatever the title should be"}); //This can fail horribly, need the try/catch logic.
            }catch (Exception){}
        }
    
        void bw_DoWork(object sender, DoWorkEventArgs e) {
            Thread.Sleep(3000);
        }
    }
