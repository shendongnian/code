    public class MyPage: Page
    {
      private List<TextBox> TxtBoxes = new List<TextBox>();
      //registered for the preinit on the page....
      public void PreInitHandler(object sender, EventArgs e)
      {
          for(var i = 0; i < 2; i++)
          {
            var txtBox = new TextBox{Id = textBox+i};
            //...add cell to table and add txtBox Control
            TxtBoxes.Add(txtBox);
          }
      }
    }
