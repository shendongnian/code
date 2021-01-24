    Smartsheet.Api.SmartsheetClient a = new 
    Smartsheet.Api.SmartsheetBuilder().SetAccessToken("yourtoken").Build();
    a.SheetResources.RowResources.UpdateRows(sheetId, new List<Row>
    {
        new Row{ Id =rowId, Cells = new List<Cell>{
            new Cell{ ColumnId = columnId, ObjectValue = new  MultiContactObjectValue(new List<ContactObjectValue>{
                new ContactObjectValue{ Name = "Name", Email = "test@email.com"},
                new ContactObjectValue{ Name = "Name2", Email = "tes2t@email.com"}
            })
            }
          }
        }
    });
