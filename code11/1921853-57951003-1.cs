    List<CarsInfo> cars = new List<CarsInfo> { new CarsInfo("C1", "M1", 2, 1000.3), new CarsInfo("C2", "M2", 5, 7654.34), new CarsInfo("C3", "M3", 3, 3225) };
    for (int i = 0; i < cars.Count; i++)
    {
        Label CarMake = new Label();
        CarMake.AutoSize = true;
        CarMake.Location = new System.Drawing.Point(39, 34 * i + 12);
        CarMake.Name = "labelMake" + i;
        CarMake.Size = new System.Drawing.Size(35, 13);
        CarMake.Text = cars[i].CarMake;
        this.Controls.Add(CarMake);
        Label CarModel = new Label();
        CarModel.AutoSize = true;
        CarModel.Location = new System.Drawing.Point(118, 34 * i + 12);
        CarModel.Name = "labelModel" + i;
        CarModel.Size = new System.Drawing.Size(35, 13);
        CarModel.Text = cars[i].CarModel;
        this.Controls.Add(CarModel);
        TextBox CarMileage = new TextBox();
        CarMileage.Location = new System.Drawing.Point(212, 34 * i + 12);
        CarMileage.Name = "textBoxMileag" + i;
        CarMileage.Size = new System.Drawing.Size(100, 20);
        CarMileage.TabIndex = 2;
        CarMileage.Text = cars[i].Mileage.ToString();
        this.Controls.Add(CarMileage);
    }
