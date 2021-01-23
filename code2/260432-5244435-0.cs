    //Remove scripts
    str = Regex.Replace(str, "`<script.*?>`.*?`</script>`", "", RegexOptions.Singleline);  
      
    //Remove CSS styles, if any found
    str = Regex.Replace(str, "`<style.*?>`(.| )*?`</style>`", "", RegexOptions.Singleline);
    
    //Remove all HTML tags, leaving on the text inside.
    str= Regex.Replace(str, "`<(.| )*?>`", "", RegexOptions.Singleline);
    
    //Remove \r,\t,\n
    str= str.Replace("\r", "").Replace("\n", "").Replace("\t", "");
