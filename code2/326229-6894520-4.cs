    dgOrder.Columns.Add(
        new DataGridTextColumn()
        { 
            Header = "Total",
            Binding = new Binding() 
            {
                //The Value converter described above
                Converter = new TotalCostConverter(),             
            }
        }        
    
    );
  
