    using (StreamWriter writer = new StreamWriter(newPath, false, correctEncoding))
    {
        String line; 
        StreamReader sr = new StreamReader(@"C:\Users\John\Desktop\result.html"); 
        while ((line = sr.ReadLine()) != null) 
        { 
            if (line.Contains("</head>")) 
            { 
                line = "<img src=\"result_files\\image003.png\"/>" + line; 
            }
            writer.WriteLine(line);
        } 
        sr.Close(); 
    }
