        private static void SetChildGridCommandColumns(object sender, GridItemEventArgs e)
        {
            ((ImageButton)(((GridEditableItem)e.Item)["PolicyEditRecord"].Controls[0])).ImageUrl = "/controls/styles/images/editpencil.png";
            ImageButton _btnReject = (ImageButton)((GridDataItem)e.Item)["DeleteTransaction"].Controls[0];
            int _manualAdjustmentId = Convert.ToInt32(((GridDataItem)e.Item)["ManualAdjustmentId"].Text);
            int _manualAdjustmentBatchId = Convert.ToInt32(((GridDataItem)e.Item)["ManualAdjustmentBatchId"].Text);
        
            _btnReject.ImageUrl = "/controls/styles/images/decline.png";
            _btnReject.ToolTip = "Reject this item";
            _btnReject.OnClientClick = String.Format("OpenRadWindow('/controls/RejectedAdjustmentComment.aspx?manualAdjustmentId={0}&manualAdjustmentBatchId={1}', 'CommentDialog');return false;", _manualAdjustmentId, _manualAdjustmentBatchId);
        }
    
        private void SubmittedBatchesRadGrid_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
    //I deleted this section
            e.DetailTableView.EditFormSettings.EditFormType = GridEditFormType.WebUserControl;
            e.DetailTableView.EditFormSettings.UserControlName = "/Controls/RejectedAdjustmentComment.ascx";
            e.DetailTableView.EditMode = GridEditMode.PopUp;
    //
        
            e.DetailTableView.CommandItemSettings.ShowAddNewRecordButton = false;
            GridDataItem _dataItem = e.DetailTableView.ParentItem;
            e.DetailTableView.DataSource = AdjustmentAPI.GetAdjustmentsByBatch(Convert.ToInt32(_dataItem.GetDataKeyValue("BatchID").ToString()), PolicyClaimManualAdjustmentCode);
        }
