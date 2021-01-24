    public class Datagrams : LinkedList<DatagramPacket>
    {
        public Datagrams(byte[] RowData) : base()
        {
            AddLast(new DatagramPacket(RowData));
            while(Last.Value.header.Length.LastIndicator)
            {
                byte[] temp = new byte[RowData.Length - Marshal.SizeOf(Last.Value)];
                Buffer.BlockCopy(RowData, Marshal.SizeOf(Last.Value), temp, 0, RowData.Length - Marshal.SizeOf(Last.Value));
                RowData = temp;
                AddLast(new DatagramPacket(RowData));
            }
        }
    }
