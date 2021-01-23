    class ViewModelListItem {
    
      public ViewModelListItem(MyObject item) {
        this.Item = item;
      }
      public MyObject Item {
        get;
        private set;
      }
      
      public override ToString() {
        // to do: add your logic here
        if (...)
          return "case A";
        else
          return "Case B";
      }
    }
