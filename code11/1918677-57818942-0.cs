      i+=1;
      sheet.Range["B" + i.ToString()].Value = 1;                
      sheet.Range["C" + i.ToString()].Value2 = studentId.name;  
      sheet.Range["D" + i.ToString()].Value = studentId.age; 
     }        
    }
