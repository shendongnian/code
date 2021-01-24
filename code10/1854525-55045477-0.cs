    var connection = new Connection()
                {
                    Id = 1,
                    Name = "Connection",
                    Type = 5, //ODBC
                    SaveData = true,
                    RefreshOnLoad = true,
                    RefreshedVersion = 5,
                    MinRefreshableVersion = 1,
                    Background = true,
                    DatabaseProperties = new DatabaseProperties
                    {
                        Connection =
                            "connection-string",
                        Command = "SELECT * FROM dbo.MyTable1",
                    },
                };
                var connection1 = new Connection()
                {
                    Id = 2,
                    Name = "Connection1",
                    Type = 5, //ODBC
                    SaveData = true,
                    RefreshOnLoad = true,
                    RefreshedVersion = 5,
                    MinRefreshableVersion = 1,
                    Background = true,
                    DatabaseProperties = new DatabaseProperties
                    {
                        Connection =
                            "connection-string",
                        Command = "SELECT * FROM dbo.MyTable2",
                    },
                };
                connPart.Connections.Append(connection);
                connPart.Connections.Append(connection1);
                QueryTablePart qt = worksheetPart.AddNewPart<QueryTablePart>("part1");//IMPORTANT
                QueryTablePart qt2 = worksheetPart.AddNewPart<QueryTablePart>("part2");//IMPORTANT
                qt.QueryTable = new QueryTable()
                {
                    Name = "Connection",
                    ConnectionId = connection.Id,
                    AutoFormatId = 16,
                    ApplyNumberFormats = true,
                    ApplyBorderFormats = true,
                    ApplyFontFormats = true,
                    ApplyPatternFormats = true,
                    ApplyAlignmentFormats = false,
                    ApplyWidthHeightFormats = false,
                    AdjustColumnWidth = true,
                    Headers = false,
                    RefreshOnLoad = true
                };
                qt2.QueryTable = new QueryTable()
                {
                    Name = "Connection1",
                    ConnectionId = connection1.Id,
                    AutoFormatId = 16,
                    ApplyNumberFormats = true,
                    ApplyBorderFormats = true,
                    ApplyFontFormats = true,
                    ApplyPatternFormats = true,
                    ApplyAlignmentFormats = false,
                    ApplyWidthHeightFormats = false,
                    AdjustColumnWidth = true,
                    Headers = false,
                    RefreshOnLoad = true
                };
                // Append a new worksheet and associate it with the workbook.
                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "mySheet"
                };
                sheets.Append(sheet);
                sheets.Append(qt.QueryTable);
                sheets.Append(qt2.QueryTable);
                DefinedNames definedNames = new DefinedNames();
                // Create a new range (name matching the QueryTable name) 
                DefinedName definedName = new DefinedName() { Name = "Connection", Text = "mysheet!$B$2:$B$2",  };
                DefinedName definedName1 = new DefinedName() { Name = "Connection1", Text = "mysheet!$C$2:$C$2", };
                definedNames.Append(definedName);
                definedNames.Append(definedName1);
                workbookpart.Workbook.Append(definedNames);
                workbookpart.Workbook.Save();
