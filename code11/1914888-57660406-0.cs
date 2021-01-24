    byte[] fileBytes = File.ReadAllBytes(path);
    
    StringBuilder sb = new StringBuilder();
    foreach (var b in fileBytes)
    {
        // handle printable characters
        if ((b >= 32) || (b == 10) || (b == 13) || (b == 9)) // lf, cr, tab
            sb.Append((char)b);
        else
        {
            // handle control characters
            switch (b)
            {
                case 0: sb.Append("(nul)"); break;
                case 27: sb.Append("(esc)"); break;
                    // etc.
            }
        }
    }
    
    return sb.ToString();
