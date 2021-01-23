    List<MyHeaders> headers = new List<MyHeaders>();
    headers.Add( new MyHeaders{ID=10, Name="Yo"} );
    headers.Add( new MyHeaders{ID=2, Name="OY"} );
    headers.Add( new MyHeaders{ID=3, Name="Pickles"} );
    headers.Add( new MyHeaders{ID=4, Name="Florky"} );
    
    this.comboBox1.DataSource = headers;
    this.comboBox1.DisplayMember = "Name";
    this.comboBox1.ValueMember = "ID";
