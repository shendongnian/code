        public static async Task<Byte[]> ReadChunkAsync(this Stream me) {
            var size = BitConverter.ToUInt32(await me.ReadExactAsync(4), 0);
            checked {
                return await me.ReadExactAsync((int)size);
            }
        }
        public static async Task<Byte[]> ReadExactAsync(this Stream me, int count) {
            var buf = new byte[count];
            var t = 0;
            while (t < count) {
                var n = await me.ReadAsync(buf, t, count - t);
                if (n <= 0) {
                    if (t > 0) throw new IOException("End of stream (fragmented)");
                    throw new IOException("End of stream");
                }
                t += n;
            }
            return buf;
        }
        public static void WriteChunk(this Stream me, byte[] buffer, int offset, int count) {
            me.Write(BitConverter.GetBytes(count), 0, 4);
            me.Write(buffer, offset, count);
        }
