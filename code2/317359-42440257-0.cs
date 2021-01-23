        using System;
        using System.IO;
        using System.Collections.Generic;
        internal static class StreamReaderExtensions
        {
            public static IEnumerable<string> ReadUntil(this StreamReader reader, string delimiter)
            {
                List<char> buffer = new List<char>();
                CircularBuffer<char> delim_buffer = new CircularBuffer<char>(delimiter.Length);
                while (reader.Peek() >= 0)
                {
                    char c = (char)reader.Read();
                    delim_buffer.Enqueue(c);
                    if (delim_buffer.ToString() == delimiter || reader.EndOfStream)
                    {
                        if (buffer.Count > 0)
                        {
                            if (!reader.EndOfStream)
                            {
                                buffer.Add(c);
                                yield return new String(buffer.ToArray()).Substring(0, buffer.Count - delimeter.Length);
                            }
                            else
                            {
                                buffer.Add(c);
                                if (delim_buffer.ToString() != delimiter)
                                    yield return new String(buffer.ToArray());
                                else
                                    yield return new String(buffer.ToArray()).Substring(0, buffer.Count - delimeter.Length);
                            }
                            buffer.Clear();
                        }
                        continue;
                    }
                    buffer.Add(c);
                }
            }
        
            private class CircularBuffer<T> : Queue<T>
            {
                private int _capacity;
        
                public CircularBuffer(int capacity)
                    : base(capacity)
                {
                    _capacity = capacity;
                }
        
                new public void Enqueue(T item)
                {
                    if (base.Count == _capacity)
                    {
                        base.Dequeue();
                    }
                    base.Enqueue(item);
                }
        
                public override string ToString()
                {
                    List<String> items = new List<string>();
                    foreach (var x in this)
                    {
                        items.Add(x.ToString());
                    };
                    return String.Join("", items);
                }
            }
        }
