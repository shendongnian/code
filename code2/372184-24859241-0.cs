    public class PersonalModel
    {
        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public JQGrid OrdersGrid { get; set; }
        public PersonalModel()
        {            
                        
            OrdersGrid = new JQGrid
                             {
                                 Columns = new System.Collections.List()
                                {
                                     new JQGridColumn { DataField = "PersonId", 
                                                        // always set PrimaryKey for Add,Edit,Delete operations
                                                        // if not set, the first column will be assumed as primary key
                                                        PrimaryKey = true,
                                                        Editable = false,
                                                        Width = 50 },                                    
                                     new JQGridColumn { DataField = "FirstName", 
                                                        Editable = true,
                                                        Width = 100 },
                                     new JQGridColumn { DataField = "LastName",                                                         
                                                        Editable = true,
                                                        Width = 100, 
                                                        },
                                     new JQGridColumn { DataField = "Address", 
                                                        Editable = true,
                                                        Width = 75 },
                                     new JQGridColumn { DataField = "City",
                                                        Editable =  true
                                                      }                                     
                                 },
                                 Width = Unit.Pixel(640),
                                 Height = Unit.Percentage(100)
                             };
            OrdersGrid.ToolBarSettings.ShowRefreshButton = true;            
        }
        
    }
}
