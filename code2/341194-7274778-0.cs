    private void fooHandler(object sender, RoutedEventArgs e)
    {
        fooObject objectFoo = (fooObject)sender;
    
        // use the base class and work with that.
        // all windows have the properties you use 
        // below, so there is no need to declare it
        // as a more specific type.
        blahWindow bla = null; 
        if (objectFoo.name == "bla1"){
            bla = new bla1Window();
        }
        if (objectFoo.name == "bla2"){
            bla = new bla2Window();
        }
        .
        .
        .
        else{
            //default stuff happens
            bla = new BlahDefault();
        }
    
        // 'bla' cannot be nbull here if each branch above assigns it
        bla.Left = this.Left
        bla.Top = this.Top
        bla.Show();
        this.Close();
    }
