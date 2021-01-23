    class NewObject
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }
    
    List<NewObject> arrangedData = new List<NewObject>();
    // arrange the data here
    yourGrid.DataSource = arrangedData;
    yourGrid.DataBind();
