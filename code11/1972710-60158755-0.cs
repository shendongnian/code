    /// Copies the <see cref="ConcurrentQueue{T}"/> elements to a new <see
    /// cref="T:System.Collections.Generic.List{T}"/>.
    /// </summary>
    /// <returns>A new <see cref="T:System.Collections.Generic.List{T}"/> containing a snapshot of
    /// elements copied from the <see cref="ConcurrentQueue{T}"/>.</returns>
    private List<T> ToList()
    {
       // Increments the number of active snapshot takers. This increment must happen before the snapshot is 
       // taken. At the same time, Decrement must happen after list copying is over. Only in this way, can it
       // eliminate race condition when Segment.TryRemove() checks whether m_numSnapshotTakers == 0. 
       Interlocked.Increment(ref m_numSnapshotTakers);
    
       List<T> list = new List<T>();
       try
       {
           //store head and tail positions in buffer, 
           Segment head, tail;
           int headLow, tailHigh;
           GetHeadTailPositions(out head, out tail, out headLow, out tailHigh);
    
           if (head == tail)
           {
               head.AddToList(list, headLow, tailHigh);
           }
           else
           {
               head.AddToList(list, headLow, SEGMENT_SIZE - 1);
               Segment curr = head.Next;
               while (curr != tail)
               {
                   curr.AddToList(list, 0, SEGMENT_SIZE - 1);
                   curr = curr.Next;
               }
               //Add tail segment
               tail.AddToList(list, 0, tailHigh);
           }
       }
       finally
       {
           // This Decrement must happen after copying is over. 
           Interlocked.Decrement(ref m_numSnapshotTakers);
       }
       return list;
    }
