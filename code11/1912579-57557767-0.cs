    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.IO.Pipelines;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        class Program
        {
            private static readonly IEnumerable<IPEndPoint> ipAddresses = new[]
            {
                new IPEndPoint(IPAddress.Loopback, 8087),
                // more here.
            };
    
            internal static async Task Main()
            {
                await Task.WhenAll((await Task.WhenAll(
                        ipAddresses.Select(OpenSocket)))
                    .SelectMany(p => p));
                
                // Handling code in ProcessLine.
            }
    
            private static async Task<IEnumerable<Task>> OpenSocket(
                    EndPoint iPEndPoint)
            {
                var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                await socket.ConnectAsync(iPEndPoint);
                var pipe = new Pipe();
    
                var attendants = new[]
                {
                    FillPipeAsync(socket, pipe.Writer),
                    ReadPipeAsync(socket, pipe.Reader)
                };
    
                return attendants;
            }
    
            private static async Task FillPipeAsync(Socket socket, PipeWriter writer)
            {
                const int minimumBufferSize = 512;
    
                while (true)
                {
                    try
                    {
                        // Request a minimum of 512 bytes from the PipeWriter
                        var memory = writer.GetMemory(minimumBufferSize);
    
                        var bytesRead = await socket.ReceiveAsync(
                                 memory,
                                 SocketFlags.None);
    
                        if (bytesRead == 0)
                        {
                            break;
                        }
    
                        // Tell the PipeWriter how much was read
                        writer.Advance(bytesRead);
                    }
                    catch
                    {
                        break;
                    }
    
                    // Make the data available to the PipeReader
                    var result = await writer.FlushAsync();
    
                    if (result.IsCompleted)
                    {
                        break;
                    }
                }
    
                // Signal to the reader that we're done writing
                writer.Complete();
            }
    
            private static async Task ReadPipeAsync(Socket socket, PipeReader reader)
            {
                while (true)
                {
                    var result = await reader.ReadAsync();
                    var buffer = result.Buffer;
                    SequencePosition? position;
    
                    do
                    {
                        // Find the EOL
                        position = buffer.PositionOf((byte)'\n');
    
                        if (position == null)
                        {
                            continue;
                        }
    
                        var line = buffer.Slice(0, position.Value);
                        ProcessLine(socket, line);
    
                        // This is equivalent to position + 1
                        var next = buffer.GetPosition(1, position.Value);
    
                        // Skip what we've already processed including \n
                        buffer = buffer.Slice(next);
                    } while (position != null);
    
                    // We sliced the buffer until no more data could be processed
                    // Tell the PipeReader how much we consumed and how much we
                    // left to process
                    reader.AdvanceTo(buffer.Start, buffer.End);
    
                    if (result.IsCompleted)
                    {
                        break;
                    }
                }
    
                reader.Complete();
            }
    
            private static void ProcessLine(
                    Socket socket,
                    in ReadOnlySequence<byte> buffer)
            {
                Console.Write($"[{socket.RemoteEndPoint}]: ");
    
                foreach (var segment in buffer)
                {
                    Console.Write(Encoding.UTF8.GetString(segment.Span));
                }
    
                Console.WriteLine();
            }
        }
    }
