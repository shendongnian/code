    public void ChangeItem(object o,EventArgs e){
       string ImageId = MyGrid.SelectedDataKey.Value.ToString();
       selectedimage.Src = "GetImage.aspx?entityId="+ImageId+"&entityType=T";
    }
    
