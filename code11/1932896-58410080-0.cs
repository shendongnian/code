     string fileName = dir + "\\" + serialNumber[f] + ".ma" ;  
    try  
       {  
       using (StreamWriter writer = new StreamWriter(fileName))  
          {  
            string maHeaderLine1 = "TITLE: S/N:" + serialNumber[f] + "\n";
            string maHeaderLine2 = "ENGLISH(IN)/METRIC(MM) INDICATOR :IN-P\n";
            writer.Write(maHeaderLine1 + maHeaderLine2);  
          }  
       }  
    catch(Exception exp)  
       {  
          Console.Write(exp.Message);  
       }
}
