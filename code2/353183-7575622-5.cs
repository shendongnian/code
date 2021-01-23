    private void method() {
      if (condition) {
        var data = GetSomeData();
        if (data.IsValid) {
          var moreData = GetSomeMoreData();
          if (moreData.IsValid) {
            //DO STUFF
            return;
          }
        }
      }
      MessageBox.Show("ERROR!");
    }
