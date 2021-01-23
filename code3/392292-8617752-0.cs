    StringBuilder filename = new StringBuilder();
    using (FileStream stream = new FileStream(args[0], FileMode.Open, FileAccess.Read))
    {
        byte[] buffer = new byte[1];
        while (stream.Read(buffer, 0, 1) > 0)
        {
            char c = (char) buffer[0];
            if (char.IsLetter(c) || char.IsPunctuation(c))
                filename.Append(c);
        }
    }
