    public string[] CheckboxListSelections(System.Web.UI.WebControls.CheckBoxList list)
    {
     ArrayList values = new ArrayList();
     for(int counter = 0; counter < list.Items.Count; counter++)
     {
      if(list.Items[counter].Selected)
      {
       values.Add(list.Items[counter].Value);
      }    
     }
     return (String[]) values.ToArray( typeof( string ) );
    }
