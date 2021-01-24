    using System.Runtime.InteropServices;
    
    //Turn memory space into ArraySegment for port use
    if (!MemoryMarshal.TryGetArray(memory, out ArraySegment<byte> arraySegment))
    {
        throw new InvalidOperationException("Buffer backed by array was expected");
    }
    
    int bytesRead = port.Read(arraySegment.Array, 1000);
