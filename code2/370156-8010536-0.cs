    private void UpdateShape()
    {
        grdShapeContainer.Children.Clear();
        if(this.Shape != null)
        {
            grdShapeContainer.Children.Add(this.Shape);
        }
    }
