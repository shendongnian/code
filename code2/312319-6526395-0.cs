    Domain.Box updatedBox = entities.Boxes.FirstOrDefault(TextBoxBoxID.Text);
    UpdateBoxInfo(updatedBox);
    entities.SaveChanges();
    
    private void UpdateBoxInfo(Domain.Box theBox)
        {
            theBox.BoxID = TextBoxBoxID.Text;
            theBox.LocationID = Convert.ToDecimal(TextBoxLocationID.Text);
            theBox.Positions = Convert.ToByte(TextBoxPositions.Text);            
            theBox.DiseaseID = RadComboBoxDisease.SelectedValue;
            theBox.SampleTypeID = RadComboBoxSampleType.SelectedValue;
            theBox.TubeTypeId = RadComboBoxTubeTypeID.SelectedValue;
        }
