    // Execute it once when initializing datagridview
    var approvedColumn = new DataGridViewImageColumn
    {
        Name = "dgvCars_Approved",
        HeaderText = "Approved",
        DataPropertyName = "Approved", // This will bound column to the property of the object
    };
    dgvCars.Columns.Add(approvedColumn);
    // DataGridView will automatically pick up correct image
    var cars = (
        from u in db.Cars
        .......... 
        select new
        {
           .....
           .....                                                
           Approved = u.Treated == true ? Resources.approved : Resources.Cancel
        }).ToList();
        // Check for null is redundant, because ToList() never returns null
        // Because cars is a new instance 
        // set .DataSource to null before actual value is redundant as well
        dgvCars.DataSource = cars;
