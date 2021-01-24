            olvColumn2.IsButton = true;
            olvColumn2.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            olvColumn2.AspectGetter =(s)=>"Kill";
            olv.ButtonClick += (s, e) => 
            {
                if(e.Column == olvColumn2) 
                    try
                    {
                        if(File.Exists((string)e.Model))
                            File.Delete((string)e.Model);
                        else
                            MessageBox.Show("File not found");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            };
