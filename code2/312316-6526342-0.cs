    Domain.Box updatedBox = entities.Boxes.FirstOrDefault(TextBoxBoxID.Text);
    getBoxInfo(ref updatedBox);
    entities.SaveChanges();
    private void getBoxInfo(ref Domain.Box retBox)
    {
        retBox.BoxID = TextBoxBoxID.Text;
        ...
    }
    entities.SaveChanges();
