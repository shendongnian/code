            <telerik:RadGridView.Columns> 
                <telerik:GridViewDataColumn   DataMemberBinding="{Binding UserName}" Width="200">
                    <telerik:GridViewDataColumn.Header> 
                        <TextBlock Text="{Binding Columnheader1}"></TextBlock> 
                    </telerik:GridViewDataColumn.Header> 
                    </telerik:GridViewDataColumn> 
                <telerik:GridViewDataColumn Header="{Binding Columnheader2}" DataMemberBinding="{Binding IsOnline}" MinWidth="200" Width="*"/> 
                <telerik:GridViewDataColumn Header="{Binding Columnheader3}" DataMemberBinding="{Binding LastActivityDate}" MinWidth="200"/> 
            </telerik:RadGridView.Columns> 
                               
