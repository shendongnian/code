    List<string> ctrlNames = new List<string>();
    FIndAllCtrls(ctrlNames , this.Controls);
    
    private void FIndAllCtrls(ctrlNames, ControlCollection ctrlColl)
    {
       foreach(Control ctrl in ctrlColl)
       {
          ctrlNames.Add(ctrl.Name);
          if(ctrl.Controls.Count > 0)
             FIndAllCtrls(ctrlNames, ctrl.Controls);
       }
    }
