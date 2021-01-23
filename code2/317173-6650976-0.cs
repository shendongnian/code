    const string FileName = @"D:\ItemID.txt";
    private bool CheckExisting(string itemId)
    {
        return File.ReadLines(FileName)
                   .Contains(itemId);
    }
    
    private void WriteNewLog(string itemId)
    {
        using (TextWriter writer = File.AppendText(FileName))
        {
            writer.WriteLine(itemId);
        }
    }
    
    // Adjust name appropriately
    protected void FooHandler(int num)
    {
        for (int i = 0; i < num; i++)
        {
            // Probably use i here somewhere?
            if (!CheckExisting(itemId))
            {
                WriteNewLog(itemId);
            }  
        }    
    }
