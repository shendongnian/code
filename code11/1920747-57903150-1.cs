    if (File.Exists(filename))
    {
        var batchesOf7Lines = 
            File.ReadLines(filename)
           .Partition(batchSize:7)
           .Select(batch => batch.Items.ToArray());
        foreach (var batch in batchesOf7Lines)
        {
            // batch[] is an array of 7 strings (or less if the file is NOT a multiple of 7 lines!)
            // Do something with batch[].
        }
    }
