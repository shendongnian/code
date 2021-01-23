    static Form1 form1;
    static Form2 form2;
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        form2 = new Form2();
        form1 = new Form1();
        form2.Hide();
        form1.VisibleChanged += OnForm1Changed;
        Application.Run(form1);
    }
    static void OnForm1Changed( object sender, EventArgs args )
    {
        if ( !form1.Visible )
        {
            form2.Show( );
        }
    }
