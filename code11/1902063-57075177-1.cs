static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);        
        Form1 newForm = new Form1();           
        newForm.LoadData(); 
        Application.Run(newForm);
    }
You also save the data before it is changed. 
The __SaveData()__ method would be better before closing the application. So extending or previous code would be:
static void Main()
{
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);  
    Form1 newForm = new Form1();           
    newForm.LoadData(); 
    Application.ApplicationExit += (o, e) => newForm.SaveData();      
    Application.Run(newForm );
}
