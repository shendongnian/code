      protected override void OnCreateControl()
      {
         base.OnCreateControl();
         if (Items.Count == 0)
         {
            Items.Add("Product 1");
            Items.Add("Product 2");
         }
      }
