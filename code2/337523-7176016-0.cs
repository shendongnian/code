        try
        {
                int x = this.Ong;
        }
        catch ( Exception ex )
        {
                Console.WriteLine ( Regex.Match ( ex.StackTrace, @"get_(.*)\(\)" ).Groups[0].Value );
        }
