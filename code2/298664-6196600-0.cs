    MyControl ucAttachments1 = new MyControl();
    ucAttachments1 = (MyControl) Page.LoadControl("~/controls/mycontrol.ascx");
     ucAttachments1.ID = "ucAttachments1";
      ucAttachments1.Directory = "/uploads/documents";
      ucAttachments1.DataChanged += new MyControl.DataChangedEventHandler(DoSomething);
      phAttachments1.Controls.Add(ucAttachments1);
    
    
    MyControl ucAttachments2 = new MyControl();
    ucAttachments2 = (MyControl) Page.LoadControl("~/controls/mycontrol.ascx");
    ucAttachments2.ID = "ucAttachments2";
      ucAttachments2.Directory = "/uploads/drawings";
      ucAttachments2.DataChanged += new MyControl.DataChangedEventHandler(DoSomething);
      phAttachmetns2.Controls.Add(ucAttachments2);
