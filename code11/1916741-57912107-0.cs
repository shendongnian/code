    class Program
    {
        [FixedLengthRecord]
        class ReadBarCodes
        {
            [FieldFixedLength(6)]
            public string cbDate;
            [FieldFixedLength(6)]
            [FieldConverter(typeof(MyDoubleConverter))]
            public double poidsNet;
            [FieldFixedLength(4)]
            public string dix;
            [FieldFixedLength(6)]
            public string lot;
        }
        public class MyDoubleConverter : ConverterBase
        {
            public override object StringToField(string from)
            {
                // When importing, 'from' will contain the string from the file "011780"
                return Convert.ToDouble(Double.Parse(from) / 100);
            }
            public override string FieldToString(object fieldValue)
            {
                // When exporting, do the opposite: remove the decimal point.
                return ((double)fieldValue).ToString("#.##").Replace(".", "");
            }
        }
        public static void Main(string[] args)
        {
            var fileContent = "(3102)011780(10)772890";
            var engine = new FileHelperEngine<ReadBarCodes>();
            var records = engine.ReadString(fileContent);
            if (records[0].poidsNet == 117.80)
                Console.WriteLine("The poidsNet field was correctly read as 117.80.");
            else
                Console.WriteLine("Failed to read poidsNet correctly.");
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
