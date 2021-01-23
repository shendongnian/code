     public class BinaryResponse {
    
            private BinaryReader _rdr;
            public BinaryResponse(byte[] responseBytes) {
                _rdr = new BinaryReader(new MemoryStream(responseBytes)); // wrap the byte[] in a BinaryReader to be able to pop the bytes off the top
            }
    
            protected void ParseResponseSection(CountData countData) {
                countData.quoteCount = _rdr.ReadInt16(); // guessing 64.000 quotes should be enough in one response, the documentation will have the type      
            }
    
            protected void ParseResponseSection(SymbolData symbolData) {
                symbolData.errorCode = _rdr.ReadByte(); // depending on your format, where is the ErrorCOde in the byte[]? the symbol might be first
    
                int symbolLength = _rdr.ReadInt16(); // if it's not written by a .Net WriteString on the other end better to read this count yourelf
                symbolData.symbol = new string(_rdr.ReadChars(symbolLength)); // read the chars and put into string
            }
    
            protected void ParseResponseSection(ErrorData errorData) {
                int errorLenth = _rdr.ReadInt16();
                errorData.errorText = new string(_rdr.ReadChars(errorLenth));
            }
    
            protected void ParseResponseSection(ChartBarData chartBarData) {
                chartBarData.chartBarCount = _rdr.ReadInt16();
            }
    
            protected void ParseResponseSection(ChartBar chartBar) {
                // check the order with the documentation, also maybe some casting is needed because other types are in the byte[]
                chartBar.close = _rdr.ReadSingle();
                chartBar.high = _rdr.ReadSingle();
                chartBar.low = _rdr.ReadSingle();
                chartBar.open = _rdr.ReadSingle();
                chartBar.timestamp = _rdr.ReadInt64();
            }
    
            protected void ParseResponseSection(EndingDelimiterSection endingDelimiterSection) {
                int checkValue = _rdr.ReadInt16();
                if (checkValue != 12345) throw new InvalidDataException("Corrupt Response! Expecting End Delimiter"); // assert that the end delimiter is some value
            }
        }
