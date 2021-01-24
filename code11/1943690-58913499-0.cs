    case SuperTapiModel.ColumnType.DataGridTextColumn:
    {
        DataGridTextColumn dgcText = new DataGridTextColumn();
        dgcText.Binding = new Binding("The name of the property");
        newColumn = dgcText;
    }
    break;
