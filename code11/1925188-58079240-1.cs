       stringBuilder.Append('"'); // Quotation at the very beginning
    
       for (var i = 0; i < actualSetpointCount; i++) {
         if (i > 0)        // If we have items put
           sb.Append(","); // we should add a delimiter BEFORE the next item
    
         sb.Append(arrayDataSet[i]);
       }
    
       stringBuilder.Append('"'); // Quotation at the very end
