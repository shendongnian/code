            <telerik:GridTemplateColumn UniqueName="ADDCombo">
                <ItemTemplate>
                </ItemTemplate>
               </telerik:GridTemplateColumn>
...............
     if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            
            //get data key
            string strID = item.GetDataKeyValue("ID").ToString();
            RadComboBox RadComboBox2 = new RadComboBox();
            // bind your combo here
            item["ADDCombo"].Controls.Add(RadComboBox2);
        }
