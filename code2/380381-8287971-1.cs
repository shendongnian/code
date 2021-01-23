    namespace GraphicW_Array
        {
          public class Lot
          {
            public void addPiece(int piece, Board myPAge)
            {
                lotPresent[lotLoad] = piece;
                lotLoad++;
                myPage.btnPanel_OnClick(null,EventArgs.Empty);
            }
          }
        }
