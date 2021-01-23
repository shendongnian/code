    Workbook wbk = app.Workbooks.Add();
                
    dynamic properties = wbk.BuiltinDocumentProperties;
    dynamic property = properties.Item("Author");
    
    property.Value = "J K Rowling";    
          
