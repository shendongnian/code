    case WatcherChangeTypes.Changed:
    {
        System.IO.FileInfo fi = new FileInfo(e.FullPath);
    
        long prevLength;
    
        if (lastPositions.TryGetValue(e.FullPath, out prevLength))
        {
            using (System.IO.FileStream fs = new FileStream(
               e.FullPath, FileMode.Open, FileAccess.Read))
            {
                fs.Seek(prevLength, SeekOrigin.Begin);
                DumpNewData(fs, (int)(fi.Length - prevLength));
                lastPositions[e.FullPath] = fs.Position;
            }
        }
        else
          lastPositions.Add(e.FullPath, fi.Length);
    
        break;
    }
