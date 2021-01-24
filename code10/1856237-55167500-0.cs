       foreach (PublishedTask t in taskColl)
       {
    
          CustomFieldCollection LCFColl = t.CustomFields;
          foreach (CustomField cf in LCFColl)
          {
              // do something with the custom fields
          }
          Console.WriteLine("\t{0}.  {1, -15}       {2,-30}{3}", k++, t.Name, t.PercentComplete);
    
       }
