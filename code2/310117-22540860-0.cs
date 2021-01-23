    private void show_data()
            {
                BindingSource Source = new BindingSource();
    
                for (int i = 0; i < CC.Contects.Count; i++)
                {
                    Source.Add(CC.Contects.ElementAt(i));
                };
    
    
                Data_View.DataSource = Source;
    
            }
