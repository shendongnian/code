// write decimal to TDS stream
static byte[] DecimalBytes(decimal dec, int precision = 15)
{
    var round = decimal.Round(dec, precision);
    var valueToWrite = round;
    var sign = round < 0 ? (byte)0x00 : (byte)0x01;
    // get the string
    var str = round.ToString();
    // string without Decimal point
    var numbers = str.Replace(".", string.Empty);
    var dotIdx = str.IndexOf('.');
    if (dotIdx > 0)
    {
        // there must be {precision} digits on the right side of "."
        var padding = precision - (numbers.Length - dotIdx);
        // padding numbers with '0' to precision length
        numbers = numbers.PadRight(numbers.Length + padding, '0');
        if (!decimal.TryParse(numbers, out valueToWrite))
        {
            throw new ArgumentOutOfRangeException($"Invalid decimal value for Database Type decimal(38,{precision})");
        }
    }
    using (var ms = new System.IO.MemoryStream())
    {
        var bits = decimal.GetBits(valueToWrite);
        ms.WriteByte(0x0D); // length=13
        ms.WriteByte(sign);
        ms.Write(BitConverter.GetBytes(bits[0]), 0, 4);
        ms.Write(BitConverter.GetBytes(bits[1]), 0, 4);
        ms.Write(BitConverter.GetBytes(bits[2]), 0, 4);
        return ms.ToArray();
    }
}
