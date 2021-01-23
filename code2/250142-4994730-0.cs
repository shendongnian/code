    static public void PrintIt(string inputString){    
        Document = new PrintDocument();
        Document.PrintPage += (sender, e) => Document_PrintText(e, inputString);
        Document.Print();
    }
