    // MathNet.Numerics.LinearAlgebra.Storage.MatrixStorage<T>
    using MathNet.Numerics.Properties;
    using System;
    using System.Runtime.Serialization;
    
    protected MatrixStorage(int rowCount, int columnCount)
    {
    	if (rowCount <= 0)
    	{
    		throw new ArgumentOutOfRangeException("rowCount", Resources.MatrixRowsMustBePositive);
    	}
    	if (columnCount <= 0)
    	{
    		throw new ArgumentOutOfRangeException("columnCount", Resources.MatrixColumnsMustBePositive);
    	}
    	RowCount = rowCount;
    	ColumnCount = columnCount;
    }
