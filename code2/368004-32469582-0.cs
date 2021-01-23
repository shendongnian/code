    simple and easy solution to create splash screen
    
    1. open new form use name "SPLASH"
    2. change background image whatever you want
    3. select progress bar
    4. select timer
    
    now set timer tick in timer:
    
    private void timer1_Tick(object sender, EventArgs e)
            {
                progressBar1.Increment(1);
                if (progressBar1.Value == 100) timer1.Stop();
                {
     
                }
            }
    
    
    add new form use name "FORM-1"and use following command in FORM 1.
    note: Splash form works before opening your form1
    
    1. add this library -
    
        Quote:
        using System.Threading;
    
    
    
    2. create function
    
    public void splash()
         {
     
             Application.Run(new splash());
         }
    
    
    
    
    3. use following command in initialization like below.
    
    public partial class login : Form
        {
     
    public login()
           {
               Thread t = new Thread(new ThreadStart(splash));
               t.Start();
               Thread.Sleep(15625);
     
               InitializeComponent();
     
    
    enter code here
               t.Abort();
     }
    http://solutions.musanitech.com/c-create-splash-screen/
