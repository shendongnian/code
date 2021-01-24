    //with properties    
    public class MSProject.Task 
    {
        public string Name {get; set;}
        public string code {get; set;}
    }
    
    //no properties
    public class MSProject.Task2 
    {
        public string Name;
        public string code;
    }
    
    private void ShowRownsInGrid()
    {
        //this works, show rows in DataGridView!
        List<MSProject.Task> tasks = new List<MSProject.Task>()
            {
                new MSProject.Task(){ Name = "Joao", code = "01215452124"},
                new MSProject.Task(){ Name = "Maria", code = "4564678"},
            };
            DataTable Tabla = new DataTable();
            Tabla = ListToDataTable(tasks);
            dataGridView1.DataSource = Tabla;
     }
 
    private void DontShowRownsInGrid()
    {
         //this won't work, no rows in DataGridView!
         List<MSProject.Task2> tasks = new List<MSProject.Task2>()
            {
                new MSProject.Task2(){ Name = "Joao", code = "01215452124"},
                new MSProject.Task2(){ Name = "Maria", code = "4564678"},
            };
            DataTable Tabla = new DataTable();
            Tabla = ListToDataTable(tasks);
            
            dataGridView1.DataSource = Tabla;
     }
        
