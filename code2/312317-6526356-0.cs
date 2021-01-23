    Domain.Box updatedBox = entities.Boxes.FirstOrDefault(TextBoxBoxID.Text);
    getBoxInfo(ref updatedBox);
    entities.SaveChanges();
    
    private void getBoxInfo(ref Domain.Box retBox)
        {
            retBox.BoxID = TextBoxBoxID.Text;
            retBox.LocationID = Convert.ToDecimal(TextBoxLocationID.Text);
            retBox.Positions = Convert.ToByte(TextBoxPositions.Text);            
            retBox.DiseaseID = RadComboBoxDisease.SelectedValue;
            retBox.SampleTypeID = RadComboBoxSampleType.SelectedValue;
            retBox.TubeTypeId = RadComboBoxTubeTypeID.SelectedValue;
        }
