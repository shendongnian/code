    public class StreamMediaDataSource : MediaDataSource
    { 
    ...
        public override int ReadAt(long position, byte[] buffer, int offset, int size)
        {
            // data.Seek(position, System.IO.SeekOrigin.Begin); remove seeking
            return data.Read(buffer, offset, size);
        }  
    ... // rest of your code remains same. 
    }
