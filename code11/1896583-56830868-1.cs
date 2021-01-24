     public class Datagrams : LinkedList<DatagramPacket>
    {
        public Datagrams(byte[] RowData) : base()
        {
            AddLast(new DatagramPacket(RowData));
            while(Last.Value.header.Length.LastIndicator)
            {
                int index = Marshal.SizeOf<DatagramPacket.DatagramHeader>() + Last.Value.header.Length.Length + sizeof(UInt16);
                byte[] temp = new byte[RowData.Length - index];
                Buffer.BlockCopy(RowData, index, temp, 0, RowData.Length - index);
                RowData = temp;
                AddLast(new DatagramPacket(RowData));
            }
        }
    }
