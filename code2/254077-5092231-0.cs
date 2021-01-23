    public delegate string getCurrentItemCallBack (int location);
    ...
    private string GetCurrentItem(int location)
    {
       if (this.listViewModels.InvokeRequired)
          {
           getCurrentItemCallback d = new getCurrentItemCallback(GetCurrentItem);
           return this.Invoke(d, new object[] { location });
          }
          else
          {
           return this.listViewModels.Items[location].ToString();
          }
    }
