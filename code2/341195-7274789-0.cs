    private void fooHandler(object sender, RoutedEventArgs e)
    {
        Window bla = null;
        fooObject objectFoo = (fooObject)sender;
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
        }
        if(bla != null)
        {
            bla.Left = this.Left
            bla.Top = this.Top
            bla.Show();
            this.Close();
        }
    }
