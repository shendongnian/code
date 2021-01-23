    public struct GD { public double x, y, a, b, c, d; public byte t; }
    public struct Coordinate { public double locX, locY, oriX, oriY, xAxis, yAxis; } 
    public class PDFMask
    {
        private string _name;
        public string fun;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Contains("{"))
                {
                    _name = value.Substring(0, value.IndexOf("{"));
                    fun = value.Substring(value.IndexOf("{"));
                }
                else
                {
                    _name = value;
                }
            }
        }
        public string key;
        public byte[] data;
        public GD[] graphicsDirectives;
        public Coordinate coordinate;
        public void parseData(byte[] data)
        {
            this.data = data;
            graphicsDirectives = new GD[100];
            int gdCount = 0;
            byte[] buffer = new byte[100];
            int bufferCount = 0;
            for (int i = 0; i < data.Length; i++)
            {
                switch (data[i])
                {
                    case (byte)'\n':
                        if (bufferCount > 2 && buffer[bufferCount - 2] == ' ' && (buffer[bufferCount - 1] == 'c' || buffer[bufferCount - 1] == 'l' || buffer[bufferCount - 1] == 'm'))
                            graphicsDirectives[gdCount++] = parseDataWriteGD(buffer, bufferCount);
                        else if (bufferCount > 3 && buffer[0] == 'q' && buffer[bufferCount - 1] == 'm' && buffer[bufferCount - 2] == 'c')
                            coordinate = parseDataWriteCoordinate(buffer, bufferCount);
                        
                        bufferCount = 0;
                        break;
                    default :
                        buffer[bufferCount++] = data[i];
                        break;
                }
            }
            GD[] actualGraphicsDirectives = new GD[gdCount];
            Array.Copy(graphicsDirectives, actualGraphicsDirectives, gdCount);
            graphicsDirectives = actualGraphicsDirectives;
        }
        public Coordinate parseDataWriteCoordinate(byte[] bytes, int count)
        {
            byte[] actualBytes = new byte[count];
            Array.Copy(bytes, actualBytes, count);
            string[] values = Encoding.ASCII.GetString(actualBytes).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Coordinate c = new Coordinate();
            c.locX = double.Parse(values[1]);
            c.locY = double.Parse(values[2]);
            c.oriX = double.Parse(values[3]);
            c.oriY = double.Parse(values[4]);
            c.xAxis = double.Parse(values[5]);
            c.yAxis = double.Parse(values[6]); 
            return c;
        }
        public GD parseDataWriteGD(byte[] bytes, int count)
        {
            byte[] actualBytes = new byte[count];
            Array.Copy(bytes, actualBytes, count);
            string[] values = Encoding.ASCII.GetString(actualBytes).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            GD gd = new GD();
            gd.t = (byte)values[values.Length - 1][0];
            if (gd.t == 'c')
            {
                gd.a = double.Parse(values[0]);
                gd.b = double.Parse(values[1]);
                gd.c = double.Parse(values[2]);
                gd.d = double.Parse(values[3]);
                gd.x = double.Parse(values[4]);
                gd.y = double.Parse(values[5]);
            }
            else
            {
                gd.x = double.Parse(values[0]);
                gd.y = double.Parse(values[1]);
            }
            return gd;
        }
    }
