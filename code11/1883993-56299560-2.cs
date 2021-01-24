    public class ColorReader {
        BitPosition bp;
    
        public ColorReader(byte[] data) => bp = new BitPosition(data);
    
        static ColorEntry[] palette = new[] {
                    new ColorEntry { marker = 0b0, color = 0xFFFFFF, sizeInBits = 1 },
                    new ColorEntry { marker = 0b10, color = 0xFF0000, sizeInBits = 2 },
                    new ColorEntry { marker = 0b110, color = 0xFF00DC, sizeInBits = 3 },
                    new ColorEntry { marker = 0b111, color = 0xFF5A0C, sizeInBits = 3 },
                };
    
        public IEnumerable<ColorEntry> Colors() {
            while (bp.HasMoreData) {
                int bitsSoFar = 0;
                int numBits = 0;
                do {
                    int nextBit = bp.ReadNextBit();
                    ++numBits;
                    bitsSoFar |= nextBit;
    
                    var nextCE = palette.FirstOrDefault(ce => ce.sizeInBits == numBits && ce.marker == bitsSoFar);
                    if (nextCE != null) {
                        yield return nextCE;
                        break;
                    }
                    else
                        bitsSoFar <<= 1;
                } while (true);
            }
        }
    }
