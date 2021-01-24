    string surname = driverComboBox.SelectedItem.ToString();
    string vehiclePlate = vehicleComboBox.SelectedItem.ToString();
    string sql = "WHERE 1=1"; //Starting point
    if (surname != "*" && surname != "") //if he selected a surname
        sql += string.Format(" AND d.surname LIKE '%{0}%' ", surname);
    if (vehiclePlate != "*" && vehiclePlate != "") //if he selected a plate
        sql += string.Format(" AND v.plate LIKE '%{0}%' ", vehiclePlate); 
    UpdateTableRows(_controllerJourney.GetByFilter(sql));
