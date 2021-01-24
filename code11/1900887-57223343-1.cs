    async ValueTask ReadSomeDataAsync(PipeReader reader)
    {
        while (true)
        {
            // await some data being available
            ReadResult read = await reader.ReadAsync();
            ReadOnlySequence<byte> buffer = read.Buffer;
            // check whether we've reached the end
            // and processed everything
            if (buffer.IsEmpty && read.IsCompleted)
                break; // exit loop
            // process what we received
            foreach (Memory<byte> segment in buffer)
            {
                string s = Encoding.ASCII.GetString(
                    segment.Span);
                Console.Write(s);
            }
            // tell the pipe that we used everything
            reader.AdvanceTo(buffer.End);
        }
    }
