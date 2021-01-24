       stringBuilder.Append('"'); // Quotation at the very beginning
    
       for (var i = 0; i < actualSetpointCount; i++) {
         if (i > 0)
           sb.Append(","); // Delimiter BEFORE the next item
    
         sb.Append(arrayDataSet[i]);
       }
    
       stringBuilder.Append('"'); // Quotation at the very end
