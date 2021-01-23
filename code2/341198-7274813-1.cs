    Window CreateFromName(string name) {
        if (name == "bla1"){
            return new bla1Window();
        } else if (name == "bla2"){
            return new bla2Window();
        } else {
            // just make sure to return a value
            // or there will a compiler error later
        }
    }
    private void fooHandler(object sender, RoutedEventArgs e)
    {
        fooObject objectFoo = (fooObject)sender;
        Window bla = CreateFromName(objectFoo.name);
        bla.Left = this.Left
        bla.Top = this.Top
        bla.Show();
        this.Close();
    }
