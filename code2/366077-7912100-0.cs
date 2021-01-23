    public void UpdateMyTab(MyTab currentMyTab) {          
      var original = this.ChangeSet.GetOriginal(currentMyTab);
      
      if (original != null) {
        this.ObjectContext.MyTabs.AttachAsModified(currentMyTab, original);
      }
      else {
        this.ObjectContext.MyTabs.Attach(currentMyTab);
      }
    }
