    public static IEnumerable<T[]> GetPackets<T>(this IList<T> buffer, T delimiter)
    {
        // gets delimiters' indexes
        var delimiterIdxs = Enumerable.Range(0, buffer.Count())
                                        .Where(i => buffer[i].Equals(delimiter))
                                        .ToArray();
        // creates a list of delimiters' indexes pair (startIdx,endIdx)
        var dlmtrIndexesPairs = delimiterIdxs.Take(delimiterIdxs.Count() - 1)
                                             .SelectMany((startIdx, idx) => 
                                                         delimiterIdxs.Skip(idx + 1)
                                                                      .Select(endIdx => new { startIdx, endIdx })
                                                        );
        // creates array of packets
        var packets = dlmtrIndexesPairs.Select(p => buffer.Skip(p.startIdx)
                                                          .Take(p.endIdx - p.startIdx + 1)
                                                          .ToArray())
                                       .ToArray();
    
        return packets;
    }
