SynchronizationContext _context = SynchronizationContext.Current;
private void UpdateLabels()
{
        _context.Post(x=> 
             {
                lblAccount.Text = AccountBalance.ToString();
             },null),
         
    //...
}
Alternative of SynchronizationContext :
private void UpdateLabels()
{
      var action = new Action(() => 
      {
              lblAccount.Text = AccountBalance.ToString();
      });
         
      App.Current.Dispatcher.BeginInvoke(action);
    //...
}
Both of them are same.
