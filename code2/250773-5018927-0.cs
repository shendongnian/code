     StringBuilder filter=new StringBuilder("(&(objectClass=printQueue)");
            if (!string.IsNullOrEmpty(queueName))
                filter.Append("(printerName=*"+queueName+"*)") ;
            if (!string.IsNullOrEmpty(location))
              
                filter.Append("(location=*" + location + "*)");
            if (!string.IsNullOrEmpty(modelNumber))
                
                filter.Append("(driverName=*" + modelNumber + "*)");
            filter.Append(")");
            deSearch.Filter = filter.ToString();
