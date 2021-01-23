      private void ResotorePivotItemHeaders()
        {
            if (_pivotItemHeaders.Count == pivot.Items.Count)
            {
                for (int i = 0; i < _pivotItemHeaders.Count; i++)
                    (pivot.Items[i] as PivotItem).Header = _pivotItemHeaders[i];
            }
        }
        
        private void HidePivotItemHeaders()
        {
            if (pivot.Items.Count == 0)
                return;
            _pivotItemHeaders.Clear();
            
            for (int i = 0; i<pivot.Items.Count; i++)
            {
                PivotItem item = pivot.Items[i] as PivotItem;
                _pivotItemHeaders.Add(item.Header as String);
                item.Header = "";
            }
        }
       List<String> _pivotItemHeaders = new List<string>();
