    public void addCar(Car c)
    {
        listCars.Add(c);
        listCars.DataSource = null;     //Make Datasource null otherwise you have to use IObservable collection
        listBox.DataSource = listCars;
        listBox.DisplayMember = "carName";
        listBox.ValueMember = "idCar";
        listBox.Refresh();                // Not necessary !
    }
