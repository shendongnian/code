    Microsoft.VisualBasic.FileOpen (1, WritingPath & "\FplDb.txt", OpenMode.Random, 
      RecordLength:=Marshal.SizeOf(WpRec))
    for (i = 1; i < 100 ; i++) {
      WpRec.WpIndex = FplDB(i, 1)
      WpRec.WpName = FplDB(i, 2)
      WpRec.WpLat = FplDB(i, 3)
      WpRec.WpLon = FplDB(i, 4)
      WpRec.WpLatDir = FplDB(i, 5)
      WpRec.WpLonDir = FplDB(i, 6)
      Microsoft.VisualBasic.FilePut(1, WpRec, i)
    }
    Microsoft.VisualBasic.FileClose(1)
