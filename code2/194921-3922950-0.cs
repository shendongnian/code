    public static List<Control> GetAllControls(IList ctrls)
    {
       List<Control> FormCtrls = new List<Control>();
       foreach (Control ctl in ctrls)
       {
          FormCtrls .Add(ctl);
          List<Control> SubCtrls = GetAllControls(ctl.Controls);
          FormCtrls .AddRange(SubCtrls);
       }
       return FormCtrls;
    } 
