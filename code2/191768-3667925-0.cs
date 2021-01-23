    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    namespace BigBuffer
    {
      class Storage
      {
        public Storage (string filename)
        {
          m_buffers = new SortedDictionary<int, byte []> ();
          m_file = new FileStream (filename, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
        public byte [] GetBuffer (long address)
        {
          int
            key = GetPageIndex (address);
          byte []
            buffer;
          if (!m_buffers.TryGetValue (key, out buffer))
          {
            System.Diagnostics.Trace.WriteLine ("Allocating a new array at " + key);
            buffer = new byte [1 << 24];
            m_buffers [key] = buffer;
            m_file.Seek (address, SeekOrigin.Begin);
            m_file.Read (buffer, 0, buffer.Length);
          }
          return buffer;
        }
        public void FillBuffer (byte [] destination_buffer, int offset, int count, long position)
        {
          do
          {
            byte []
              source_buffer = GetBuffer (position);
            int
              start = GetPageOffset (position),
              length = Math.Min (count, (1 << 24) - start);
            Array.Copy (source_buffer, start, destination_buffer, offset, length);
            position += length;
            offset += length;
            count -= length;
          } while (count > 0);
        }
        public int GetPageIndex (long address)
        {
          return (int) (address >> 24);
        }
        public int GetPageOffset (long address)
        {
          return (int) (address & ((1 << 24) - 1));
        }
        public long Length
        {
          get { return m_file.Length; }
        }
        public int PageSize
        {
          get { return 1 << 24; }
        }
        FileStream
          m_file;
        SortedDictionary<int, byte []>
          m_buffers;
      }
      class BigStream : Stream
      {
        public BigStream (Storage source)
        {
          m_source = source;
          m_position = 0;
        }
        public override bool CanRead
        {
          get { return true; }
        }
        public override bool CanSeek
        {
          get { return true; }
        }
        public override bool CanTimeout
        {
          get { return false; }
        }
        public override bool CanWrite
        {
          get { return false; }
        }
        public override long Length
        {
          get { return m_source.Length; }
        }
        public override long Position
        {
          get { return m_position; }
          set { m_position = value; }
        }
        public override void Flush ()
        {
        }
        public override long Seek (long offset, SeekOrigin origin)
        {
          switch (origin)
          {
          case SeekOrigin.Begin:
            m_position = offset;
            break;
          case SeekOrigin.Current:
            m_position += offset;
            break;
          case SeekOrigin.End:
            m_position = Length + offset;
            break;
          }
          return m_position;
        }
        public override void SetLength (long value)
        {
        }
        public override int Read (byte [] buffer, int offset, int count)
        {
          int
            bytes_read = (int) (m_position + count > Length ? Length - m_position : count);
          m_source.FillBuffer (buffer, offset, bytes_read, m_position);
          m_position += bytes_read;
          return bytes_read;
        }
        public override void  Write(byte[] buffer, int offset, int count)
        {
        }
        Storage
          m_source;
        long
          m_position;
      }
      class IntBigArray
      {
        public IntBigArray (Storage storage)
        {
          m_storage = storage;
          m_current_page = -1;
        }
        public int this [long index]
        {
          get
          {
            int
              value = 0;
            index <<= 2;
            for (int offset = 0 ; offset < 32 ; offset += 8, ++index)
            {
              int
                page = m_storage.GetPageIndex (index);
              if (page != m_current_page)
              {
                m_current_page = page;
                m_array = m_storage.GetBuffer (m_current_page);
              }
              value |= (int) m_array [m_storage.GetPageOffset (index)] << offset;
            }
            return value;
          }
        }
      
        Storage
          m_storage;
        int
          m_current_page;
        byte []
          m_array;
      }
      class Program
      {
        static void Main (string [] args)
        {
          Storage
            storage = new Storage (@"<some file>");
          BigStream
            stream = new BigStream (storage);
          StreamReader
            reader = new StreamReader (stream);
          string
            line = reader.ReadLine ();
          IntBigArray
            array = new IntBigArray (storage);
          int
            value = array [0];
          BinaryReader
            binary = new BinaryReader (stream);
          binary.BaseStream.Seek (0, SeekOrigin.Begin);
          int
            another_value = binary.ReadInt32 ();
        }
      }
    }
