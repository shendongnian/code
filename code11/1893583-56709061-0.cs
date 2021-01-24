<DataGrid x:Name="dgvOrderItems" Height="570" VerticalAlignment="Stretch" Width="138" HorizontalAlignment="Stretch" FontSize="10" Padding="0" HorizontalScrollBarVisibility="Hidden">
<DataGrid.ColumnHeaderHeight>20</DataGrid.ColumnHeaderHeight>
    <DataGrid.Columns>
        <DataGridTextColumn Header="Order Item" Width="108" Binding="{Binding ItemNumber}">
            <DataGridTextColumn.ElementStyle>
                <Style>
                    <Setter Property="TextBlock.TextWrapping" Value="Wrap" />
                </Style>
            </DataGridTextColumn.ElementStyle>
        </DataGridTextColumn>
        <DataGridTextColumn Header="Qty." Width="30" Binding="{Binding ItemQty}">
            <DataGridTextColumn.ElementStyle>
                <Style>
                    <Setter Property="TextBlock.TextAlignment" Value="Center" />
                </Style>
            </DataGridTextColumn.ElementStyle>
        </DataGridTextColumn>
    </DataGrid.Columns>
</DataGrid>
Class for my data:
public class SimpleOrderInfo
{
    public string ItemNumber { get; set; }
    public int ItemQty { get; set; }
    public SimpleOrderInfo(string itemNumber, int itemQty)
    {
        this.ItemNumber = itemNumber;
        this.ItemQty = itemQty;
    }
}
Setting my ItemsSource:
public List<SimpleOrderInfo> simpleOrderInfo = new List<SimpleOrderInfo>();
simpleOrderInfo = business.GetSimpleOrderInfo(orderNumber);
dgvOrderItems.ItemsSource = simpleOrderInfo;
I feel like this could still probably be cleaned up some, but it is working, and is much cleaner than what I started with.
