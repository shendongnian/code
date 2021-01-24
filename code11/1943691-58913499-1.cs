    case SuperTapiModel.ColumnType.DataGridTextColumn:
    {
        DataGridTextColumn dgcText = new DataGridTextColumn();
        dgcText.EditingElementStyle = FindResource("YourResourceKey") as Style;
        newColumn = dgcText;
    }
    break;
