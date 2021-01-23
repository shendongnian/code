    private string ExtractTextFromIFilter(IFilter filter)
    {
       var sb = new StringBuilder();
       while (true)
       {
          StatChunk chunk;
          result = filter.GetChunk(out chunk);
          if (result == FilterReturnCodes.S_OK)
          {
             if (chunk.flags == ChunkState.CHUNK_TEXT)
             {
                sb.Append(ExtractTextFromChunk(filter, chunk));
             }
             continue;
          }
          if (result == FilterReturnCodes.FILTER_E_END_OF_CHUNKS)
          {
             return sb.ToString();
          }
          Marshal.ThrowExceptionForHR((int)result);
       }
    }
    private virtual string ExtractTextFromChunk(IFilter filter, StatChunk chunk)
    {
       var sb = new StringBuilder();
       var result = FilterReturnCodes.S_OK;
       while (result == FilterReturnCodes.S_OK)
       {
          int sizeBuffer = 16384;
          var buffer = new StringBuilder(sizeBuffer);
          result = filter.GetText(ref sizeBuffer, buffer);
          if ((result == FilterReturnCodes.S_OK) || (result == FilterReturnCodes.FILTER_S_LAST_TEXT))
          {
             if((sizeBuffer > 0) && (buffer.Length > 0))
             {
                sb.Append(buffer.ToString(0, sizeBuffer));
             }
          }
    
          if (result == FilterReturnCodes.FILTER_E_NO_TEXT)
          {
             return string.Empty;
          }
          if ((result == FilterReturnCodes.FILTER_S_LAST_TEXT) || (result == FilterReturnCodes.FILTER_E_NO_MORE_TEXT))
          {
             return sb.ToString();
          }
       }
       return sb.ToString();
    }
