    private void fooHandler(object sender, RoutedEventArgs e)
    {
        fooObject objectFoo = (fooObject)sender;
        Window bla; // a super-type or interface, don't assign a value here
                    // so there will be a compile error if it was
                    // forgotten below
        if (objectFoo.name == "bla1"){
            bla = new bla1Window();
        } else if (objectFoo.name == "bla2"){
            bla = new bla2Window();
        } else {
            // just make sure to assign to bla
            // or there will a compiler error later
        }
        bla.Left = this.Left
        bla.Top = this.Top
        bla.Show();
        this.Close();
    }
