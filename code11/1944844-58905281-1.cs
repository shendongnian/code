            while (true)
            {
                var bytes = new byte[1024]
                var result = await _ffMpegProcess.StandardOutput.BaseStream.ReadAsync(bytes);
                if (result == 0)
                {
                   // no data retrieved
                }
                else
                {
                   // do something with the data
                }
            }
