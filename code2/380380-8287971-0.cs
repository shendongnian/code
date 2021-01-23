    namespace GraphicW_Array
    {
      public class Lot
      {
        public void addPiece(int piece)
        {
            lotPresent[lotLoad] = piece;
            lotLoad++;
            var myPage = new Board();
            myPage.btnPanel_OnClick(null,EventArgs.Empty);
        }
      }
    }
