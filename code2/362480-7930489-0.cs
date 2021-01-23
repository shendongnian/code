    private void ActiveBatchesRadGrid_ItemDataBound(object sender, GridItemEventArgs e)
    {
        GridDataItem _dataItem = e.Item as GridDataItem;
        if (_dataItem == null) return;
        if (_dataItem.KeyValues == "{}") { return; }
        int _counter = 0;
        Dictionary<String, String> _batchStatusTypes =
            BatchTransitions.GetBatchStatusTransition(
                EnumUtils.GetValueFromName<BatchStatusType>(_dataItem["BatchStatusName"].Text));
        //accessing the cell content directly rather than trying to access the property of the GridEditCommandColumn
        ((ImageButton)(((GridEditableItem)e.Item)["MasterEditrecord"].Controls[0])).ImageUrl = "/controls/styles/images/editpencil.png";
        //accessing the cell content directly rather than trying to access the property of the GridButtonColumn            
        ImageButton _imgbtnPromote = (ImageButton)((GridDataItem)e.Item)["MasterPromoteRecord"].Controls[0];
        ImageButton _imgbtnDelete = (ImageButton)((GridDataItem)e.Item)["MasterDeleteRecord"].Controls[0];
        foreach (KeyValuePair<String, String> _kvp in _batchStatusTypes)
        {
            if (_counter == 0)
            {
                const string _jqueryCode = "if(!$find('{0}').confirm('{1}', event, '{2}'))return false;";
                const string _confirmText = "Are you sure you want to change the status of this batch {0}?";
                _imgbtnPromote.Attributes["onclick"] = string.Format(_jqueryCode, ((Control) sender).ClientID,
                                                                     string.Format(_confirmText, _kvp.Value),
                                                                     _kvp.Value);
                _imgbtnDelete.Attributes["onclick"] = string.Format(_jqueryCode, ((Control) sender).ClientID,
                                                                    string.Format(_confirmText, _kvp.Key), _kvp.Key);
                _counter++;
                continue;
            }
            _imgbtnPromote.ImageUrl = "~/controls/styles/images/approve.png";
            _imgbtnPromote.ToolTip = string.Format("{0} batch", _kvp.Value);
            _imgbtnDelete.ImageUrl = "/controls/styles/images/decline.png";
            _imgbtnDelete.ToolTip = string.Format("{0} batch", _kvp.Key);
        }
    }
