    public class WorkInfo
    {
       public string CompanyName { Get; Set; };
       public string WorkLocation { Get; Set; };
    }
    
    public class Example
    {
    
       public List<WorkInfo> GetAList()
       {
          List<WorkInfo> result = new List<WorkInfo>();
    
          result.Add(new WorkInfo { CompanyName = "MS", WorkLocation = "Redmond" });
          result.Add(new WorkInfo { CompanyName = "Google", WorkLocation = "New York" });
          result.Add(new WorkInfo { CompanyName = "Facebook", WorkLocation = "CA" });
    
          return result;
       }
    
       public UseAList()
       {
          foreach(WorkItem wRow in  GetAList()) 
          {
            string s1 = wRow.CompanyName ;
            string s2 = wRow.WorkLocation;
    
            // process list elements s1 and s2
          }
       }
    }
