    void AddBox(int row, int col, Image mainImage, Image otherImage) {
         using(Graphics g = Graphics.FromImage(mainImage)) {
              g.DrawImage(otherImage, col * 10, row * 10);
         }
    }
