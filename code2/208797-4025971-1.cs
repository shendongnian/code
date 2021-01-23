    delegate void UpdateDelegate(int val)
    void Update(int val)
    {
      if(this.InvokeRequired())
      {
         Invoke(new UpdateDeleage(Update),new object[] {val});
         return;
      }
      this.MyProgressBar.Value = val;
    }
