    string pattern = @"\b(?:[A-Z]\.)+(?: \w+\.?)* \w+(?=,)";
    string input = @"W.M.P. van der Aalst K. Van Hee, Workflow Management: Models, Methods, and Systems (MIT Press, Cambridge, 2004) 
    A. Shtub, R. Karni, ERP: The Dynamics of Supply Chain and Process Management (Springer,Berlin, 2010)";
    
    foreach (Match m in Regex.Matches(input, pattern))
    {
        Console.WriteLine(m.Value);
    }
