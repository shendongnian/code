     public DoubliClickHanlder : IChain
     {
        public IChain NextHandler(get;set;)
 
     public void ProcessEvent(object sender, DataGridViewCellEventArgs e)
        {
          if !(this.continueCellEdit && this.NextHandler!= null)
              NextHandler.ProcessEvent(sender,e) 
        }
    
     }
