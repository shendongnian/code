public Matrix()
{
    _inMatrix = new double[ , ] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
}
After that you can just create the new matrix with the values u wanted to be there.
Matrix m1=new Matrix()
You can even create a matrix where you want your matrix to be initialized and pass it into another constructor.
public Matrix(double[,] _NewMatrix)
{
    _inMatrix = _NewMatrix;
}
and call it with
double[,] NewMatrix = new double[ , ] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
Matrix m_Matrix = new Matrix( NewMatrix );
