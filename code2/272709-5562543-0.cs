    private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
                GridView gridView = sender as GridView;
                DataView dv = gridView.DataSource;
                object c = DataView[e.ListSourceRowIndex]["Category"];
                string itemKey = c == null ? "" : c.ToString();
                if (e.IsGetData) {
                    if(AddressDoc == itemKey)
                        e.Value = true;
                    else 
                        e.Value = false;
                }
                if(e.IsSetData)
                    AddressDoc = itemKey;
            }
