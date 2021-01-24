     public IEnumerable<string> ParseLine(string toParse)
     {
         var result = new List<string>();
         bool inQuotedString = false;
         bool parsingDoubleQuote = false;
         bool inWhiteSpace = false;
         int length = toParse.Length;
         var argBuffer = new StringBuilder();
         for (var index = 0; index < length; ++index)
         {
             //if looking ahead for a double quote succeeded, just add the quote to the current arguemnt
             if (parsingDoubleQuote)
             {
                 parsingDoubleQuote = false;
                 argBuffer.Append('"');
                 //and we are done with this character, so...
                 continue;  //done with this character, time to just loop again
             }
             if (toParse[index] == '"')
             {
                 inWhiteSpace = false;
                 //look ahead one character to see if there's a double quote
                 if (index < length - 1 && toParse[index + 1] == '"')
                 {
                     parsingDoubleQuote = true;
                     continue;      //done with this character, time to just loop again
                 }
                 if (!inQuotedString)
                 {
                     inQuotedString = true;
                     continue; //done with this character, time to just loop again
                 }
                 else
                 {
                     //it's not a double quote, and we are in quotes string, so
                     inQuotedString = false;
                     //we don't add the buffer to the output args until a space or the end, so
                     continue;      //done with this character, time to just loop again
                 }
             }
             //if we are here, there's no quote, so...
             if (toParse[index] == ' ' || toParse[index] == '\t')
             {
                 if (inQuotedString)
                 {
                     argBuffer.Append(toParse[index]);
                     continue;    //done with this character, time to just loop again
                 }
                 if (inWhiteSpace)
                 {
                     //nothing to do
                     continue;     //out of the for loop
                 }
                 else
                 {
                     inWhiteSpace = true;
                     if (argBuffer.Length > 0)
                     {
                         result.Add(argBuffer.ToString());
                         argBuffer.Clear();
                         continue;       //done with this character, time to just loop again
                     }
                 }
             }
             else
             {
                 inWhiteSpace = false;
                 //no quote, no space, so...
                 argBuffer.Append(toParse[index]);
                 continue;     //done with this character, time to just loop again
             }
         }   //end of for loop
         if (argBuffer.Length > 0)
         {
             result.Add(argBuffer.ToString());
         }
         return result;
     }
