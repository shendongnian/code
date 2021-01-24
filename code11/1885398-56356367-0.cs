    public class HomeController 
    {
        
        //notice private - you can't new up a HomeController - you have to use `CreateInstance`
        private HomeController(){
            MessageBox.Show("1");
           
            //not clear from your code where oPrintController comes from??
            oPrintController.PrintAsync("192.168.2.213", Encoding.ASCII.GetBytes("string to print"));
            MessageBox.Show("2");
            MessageBox.Show("Report on tasks complete");
        }
        public static async Task<HomeController> CreateInstance() {
            var homeController = new HomeController();
            await homeController.ReportOnTasks();
            return homeController;
        }
        //don't use async void! Change to Task
        public async Task ReportOnTasks()
        {
            //not clear from your code where oPrintController comes from??
            await Task.WhenAll(oPrintController.Tasks);
            foreach(Task<PrintController.PrintResult> PR in oPrintController.Tasks)
            {
                // do something with the result of task
            }
        }
    }
