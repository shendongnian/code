    String toSplit = "C:\Projects\test\whatever\files\media\10\00\00\80\test.jpg";
    String[] parts = toSplit.Split(new String[] { @"\" });
            
    String result = String.Empty;
    for (int i = 5, i > 1; i--)
    {
       result += parts[parts.Length - i];
    }
        
    // Gives the result 10000080
