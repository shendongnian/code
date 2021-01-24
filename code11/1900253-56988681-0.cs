       public partial class Form1 : Form {
      Task t;
      public Form1() {
         InitializeComponent();
      }
      protected override void OnLoad(EventArgs e) {
         base.OnLoad(e);
         t = Prepare();
      }
      public Task waitT() {
         return Task.Run(() => {
            for (int i = 0; i < 5; i++) {
               Thread.Sleep(1000);
               Console.WriteLine("T works \n");
            }
         });
      }
      public Task waitT2() {
         return Task.Run(() => {
            for (int i = 0; i < 3; i++) {
               Thread.Sleep(1000);
               Console.WriteLine("T2 works \n");
            }
         });
      }
      public Task waitT3() {
         return Task.Run(() => {
            for (int i = 0; i < 2; i++) {
               Thread.Sleep(1000);
               Console.WriteLine("T3 works \n");
            }
         });
      }
      public async Task Prepare() {
         await Task.Run(async () => {
            await waitT();
            Console.WriteLine("T DOne.");
            await waitT2();
            Console.WriteLine("T2 DOne.");
            await waitT3();
            Console.WriteLine("T3 DOne.");
         });
      }
      protected override void OnPaint(PaintEventArgs e) {
         base.OnPaint(e);
         t.Wait();
         Console.WriteLine("Finish");
      }
