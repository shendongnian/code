    BindingSource _bs;
    
    private void Form1_Load(object sender, System.EventArgs e) {
        //  Creamos el objeto BindingSource
        _bs = new BindingSource();
        //  Establecemos la conexi?n para recuperar los datos
        //  de los Clientes.
        // 
        SqlConnection cnn = new SqlConnection("Data Source=(local);");
        string sql = "SELECT * FROM Clientes";
        SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
        DataSet ds = new DataSet();
        //  Rellenamos el objeto DataSet
        da.Fill(ds, "Clientes");
        //  Le asignamos el origen de datos al objeto BindingSource
        // 
        _bs.DataSource = ds;
        //  Objeto DataSet
        _bs.DataMember = "Clientes";
        TextBox1.DataBindings.Add("Text", _bs, "IdCliente");
        TextBox2.DataBindings.Add("Text", _bs, "Nombre");
        //  Enlazamos el control BindingNavigator
        // 
        BindingNavigator1.BindingSource = _bs;
    }
