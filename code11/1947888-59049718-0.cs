    public Form1()
    {
        InitializeComponent();
        string currentPath = Path.GetDirectoryName(Application.ExecutablePath);     
        
        Directory.SetCurrentDirectory(currentPath);    
        HDFql.Execute("CREATE TRUNCATE FILE weights.h5");
        int[,] arrInt3 = { { 1, 2, 3 }, { 3, 2, 1 }, { 3, 2, 1 } };
        HDFql.Execute("CREATE DATASET weights.h5 /dset AS INT(3, 3) VALUES FROM MEMORY " + HDFql.VariableTransientRegister(arrInt3));
    }
