    private bool eventBubbledDate = false;
    private bool eventBubbleCombi = false;
    
    protected override MyCombi_OnChange(object sender, eventargs e)
    {
      if (eventBubbledDate)
      {
        eventBubbledDate = false;
        return;
      }
      eventBubbleCombi = true;
      myDateTime.Value = myCombi.SelectedValue;
    }
    
    protected override MyDateTime_OnChange(object sender, eventargs e)
    {
      if (eventBubbleCombi )
      {
         eventBubbleCombi = false;
         return;
      }
      
      // process DateStuff here
      // update other control
      eventBubbledDate = true;
    }
