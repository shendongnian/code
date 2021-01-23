    DataGrid Grid; // This displays the data
    List<object> DataBuffer; // Frequent updates are performed on this list
    void BackgroundThreadLoop()
    {
       while(true) // This loop iterates 7000 times in 20 seconds
       {
           var result = DoSomeHeavyCalculations();
        
           // Depending on the nature of the result, you can either just add it to list
           // or perhaps modify existing entries in the list in some way.
           DataBuffer.Add(result); // The simple case
           PerformSomeUpdating(DataBuffer, result); // The complicated case
       }
    }
    Timer RefreshTimer;
    override void OnLoad()
    {
        RefreshTimer = new Timer();
        RefreshTimer.Interval = 500; // easy to experiment with this
        RefreshTimer.Tick += (s, ea) => DrawBuffer(DataBuffer);
    }
    
    void DrawBuffer(List<object> DataBuffer)
    {
        // This should copy DataBuffer and put it in the grid as fast as possible.
        // How to do this really depends on how the list changes and what it contains.
        // If it's just a list of strings:
        Grid.DataSource = DataBuffer.ToList(); // Shallow copy is OK with strings
         
        // If it's a list of some objects that have meaningful Clone method:
        Grid.DataSource = DataBuffer.Select(o => o.Clone).ToList();
       
        // If the number of elements is like constant and only some values change,
        // you could use some Dictionary instead of List and just copy values.
    }
