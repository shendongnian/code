    /// <summary>
    /// This class creates a data reader for ProductRecord data.  This is used to stream the records
    /// to the SqlBulkCopy object.
    /// </summary>
    public class ProductRecordDataReader:IDataReader
    {
        public ProductRecordDataReader(List<ProductRecord> products)
        {
            _products = products.ToList();
        }
        List<ProductRecord> _products;
        int currentRow;
        int rowCounter = 0;
        public int FieldCount
        {
            get
            {
                return 14;
            }
        }
        #region IDataReader Members
        public void Close()
        {
            //Do nothing.
        }
        public bool Read()
        {
            if (rowCounter < _products.Count)
            {
                currentRow = rowCounter;
                rowCounter++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public int RecordsAffected
        {
            get { throw new NotImplementedException(); }
        }
        public string GetName(int i)
        {
            switch (i)
            {
                case 0:
                    return "ProductSku";
                case 1:
                    return "UPC";
                case 2:
                    return "EAN";
                case 3:
                    return "ISBN";
                case 4:
                    return "ProductName";
                case 5:
                    return "ShortDescription";
                case 6:
                    return "LongDescription";
                case 7:
                    return "DFFCategoryNumber";
                case 8:
                    return "DFFManufacturerNumber";
                case 9:
                    return "ManufacturerPartNumber";
                case 10:
                    return "ManufacturerModelNumber";
                case 11:
                    return "ProductImageUrl";
                case 12:
                    return "LowestPrice";
                case 13:
                    return "HighestPrice";
                default:
                    return null;
            }
        }
        public int GetOrdinal(string name)
        {
            switch (name)
            {
                case "ProductSku":
                    return 0;
                case "UPC":
                    return 1;
                case "EAN":
                    return 2;
                case "ISBN":
                    return 3;
                case "ProductName":
                    return 4;
                case "ShortDescription":
                    return 5;
                case "LongDescription":
                    return 6;
                case "DFFCategoryNumber":
                    return 7;
                case "DFFManufacturerNumber":
                    return 8;
                case "ManufacturerPartNumber":
                    return 9;
                case "ManufacturerModelNumber":
                    return 10;
                case "ProductImageUrl":
                    return 11;
                case "LowestPrice":
                    return 12;
                case "HighestPrice":
                    return 13;
                default:
                    return -1;
            }
        }
        public object GetValue(int i)
        {
            switch (i)
            {
                case 0:
                    return _products[currentRow].ProductSku;
                case 1:
                    return _products[currentRow].UPC;
                case 2:
                    return _products[currentRow].EAN;
                case 3:
                    return _products[currentRow].ISBN;
                case 4:
                    return _products[currentRow].ProductName;
                case 5:
                    return _products[currentRow].ShortDescription;
                case 6:
                    return _products[currentRow].LongDescription;
                case 7:
                    return _products[currentRow].DFFCategoryNumber;
                case 8:
                    return _products[currentRow].DFFManufacturerNumber;
                case 9:
                    return _products[currentRow].ManufacturerPartNumber;
                case 10:
                    return _products[currentRow].ManufacturerModelNumber;
                case 11:
                    return _products[currentRow].ProductImageUrl;
                case 12:
                    return _products[currentRow].LowestPrice;
                case 13:
                    return _products[currentRow].HighestPrice;
                default:
                    return null;
            }
        }
        #endregion
        #region IDisposable Members
        public void Dispose()
        {
            //Do nothing;
        }
        #endregion
        #region IDataRecord Members
        public bool NextResult()
        {
            throw new NotImplementedException();
        }
        public int Depth
        {
            get { throw new NotImplementedException(); }
        }
        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }
        public bool IsClosed
        {
            get { throw new NotImplementedException(); }
        }
        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }
        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }
        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }
        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }
        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }
        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }
        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }
        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }
        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }
        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }
        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }
        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }
        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }
        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }
        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }
        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }
        
        public string GetString(int i)
        {
            throw new NotImplementedException();
        }
        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }
        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }
        public object this[string name]
        {
            get { throw new NotImplementedException(); }
        }
        public object this[int i]
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }
