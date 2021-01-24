        // first way to get a BitMatrix instead of a bitmap
        var writer1 = new ZXing.QrCode.QRCodeWriter();
        var bitmatrix = writer1.encode(
            "<content>",
            BarcodeFormat.QR_CODE,
            1,
            1,
            new System.Collections.Generic.Dictionary<EncodeHintType, object>());
        // second way to get a BitMatrix instead of a bitmap
        var writer2 = new ZXing.BarcodeWriter<BitMatrix>
        {
            Format = BarcodeFormat.QR_CODE,
            Renderer = new BitMatrixRenderer()
        };
        var bitmatrix2 = writer2.Write("content");
        // third way to get a 2D int array instead of a bitmap
        var writer3 = new ZXing.BarcodeWriter<int[,]>
        {
            Format = BarcodeFormat.QR_CODE,
            Renderer = new BitArray2DRenderer()
        };
        var bitarray2D = writer3.Write("content");
        public class BitMatrixRenderer : IBarcodeRenderer<BitMatrix>
        {
            public BitMatrix Render(BitMatrix matrix, BarcodeFormat format, string content)
            {
                return matrix;
            }
            public BitMatrix Render(BitMatrix matrix, BarcodeFormat format, string content, EncodingOptions options)
            {
                return matrix;
            }
        }
        public class BitArray2DRenderer : IBarcodeRenderer<int[,]>
        {
            public int[,] Render(BitMatrix matrix, BarcodeFormat format, string content)
            {
                return Render(matrix, format, content, null);
            }
            public int[,] Render(BitMatrix matrix, BarcodeFormat format, string content, EncodingOptions options)
            {
                var result = new int[matrix.Width, matrix.Height];
                for (var y = 0; y < matrix.Height; y++)
                {
                    for (var x = 0; x < matrix.Width; x++)
                    {
                        result[x, y] = matrix[x, y] ? 1 : 0;
                    }
                }
                return result;
            }
        }
