      public static void SaveEditedTask(Task task) 
      { 
        using (var context=new Entities()) 
        { 
          context.Tasks.Attach(task);
          context.ObjectStateManager.GetObjectStateEntry(task).SetModifiedProperty(t => t.IDProject);
         
          context.SaveChanges(); 
        } 
      } 
