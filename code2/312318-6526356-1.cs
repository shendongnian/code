    Domain.Box updatedBox = entities.Boxes.FirstOrDefault(TextBoxBoxID.Text);
    getBoxInfo(updatedBox);
    entities.SaveChanges();
    
    private void getBoxInfo(Domain.Box retBox)
        {
            retBox.LocationID = Convert.ToDecimal(TextBoxLocationID.Text);
            retBox.Positions = Convert.ToByte(TextBoxPositions.Text);            
            retBox.DiseaseID = RadComboBoxDisease.SelectedValue;
            retBox.SampleTypeID = RadComboBoxSampleType.SelectedValue;
            retBox.TubeTypeId = RadComboBoxTubeTypeID.SelectedValue;
        }
