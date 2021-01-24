    public static List<string> paragraph(int number, List<string> lines)
    {
        return lines.Orderby(x => x).ToList();
    }
    
