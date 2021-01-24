    public async Task<bool> UpdateCellAsync(object cell)
    {
         string parsedString = await ParseAsync("cellText");         
         //if no errors - return true, else - false
         return true;
    }
    public async Task<string> ParseAsync(string formulaText)
    {
         // if you have async methods, then await methodAsync();
         // or create or task/tasks
         await Task.Run(() => //your code in separate thread. );
         //other stuff to do
         return formulaText
    }
    
