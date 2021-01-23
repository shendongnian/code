    var encs = Encoding.GetEncodings().Select(p => p.Name);
    //var encs = Encoding.GetEncodings().Select(p => p.CodePage);
    var sb = new StringBuilder("string[] encs = new string[] {");
            
    foreach (var enc in encs) {
        sb.Append(" \"" + enc + "\",");
        // sb.Append(" " + enc + ",");
    }
    sb.Length--;
    sb.Append(" };");
    var str = sb.ToString();
    Console.WriteLine(str);
