     <GridViewName>.ClearSelection(); ----------------------------------------------------1
     foreach(var item in itemList) -------------------------------------------------------2
     {
        rowHandle =<GridViewName>.LocateByValue("UniqueProperty_Name", item.unique_id );--3
        if (rowHandle != GridControl.InvalidRowHandle)------------------------------------4
        {
            <GridViewName>.SelectRow(rowHandle);------------------------------------ -----5
        }
      }
