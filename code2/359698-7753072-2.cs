    public class Matrix<T> where T: ICloneable
    {
      // ... fields and ctor
      public Matrix<T> DeepCopy()
      {
        var cloned = new Matrix<T>(row, col);
        for (int x = 0; x < row; x++) {
          for (int y = 0; y < col; y++) {
            cloned._matrix[x][y] = (T)_matrix[x][y].Clone();
          }
        }
        return cloned;
      }
    }
