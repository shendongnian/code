    // Assuming 'input' is the original string, and that 'replacementstring1' and 'replacementstring2' contain the new info you want to replace the matching portions.
    
    input = Regex.Replace(input,"#TEST1#AT#", replacementstring2);    // This search pattern wholly contains the next one, so do this one first.
    input = Regex.Replace(input,"#TEST1#", replacementstring1);
    
