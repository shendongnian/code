                D_Grid.ItemsSource = Data;        // Data is the collection of dictionary
                foreach (var key in Data[0].Keys)
                {
                        GridViewDataColumn dataCol = null;
                        dataCol = (GridViewDataColumn)D_Grid.Columns[key];
                        if (dataCol == null)
                        {
                            dataCol = new GridViewDataColumn();
                            dataCol.Header = key;
                            dataCol.UniqueName = key;                          
                            dataCol.DataMemberBinding = new Binding()
                            {
                                Converter =new GridConverter(key); // Put your converter that will take the key and return the value from that key.
                            };
                            D_Grid.Columns.Add(dataCol);
    
                        }
                    }
 
