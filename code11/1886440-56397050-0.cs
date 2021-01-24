    string id = ""; string plane = ""; int pos = 0; int dist = 0; double apert = 0;
    id = comboBMouldID.SelectedValue.ToString();
    plane = comboBSurface.SelectedItem.ToString();
    pos = Convert.ToInt32(txtTravelPos.Text);
    var measid = dataContext.MeasResults.Where(mr => mr.MoldID == id).Count();
