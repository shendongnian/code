        [IndexerName("Chars")]
        public char this[int index]
        {
          get
          {
            StringBuilder stringBuilder = this;
            do
            {
              // … some code
                return stringBuilder.m_ChunkChars[index1];
    	      // … some more code
            }
          }
          set
          {
            StringBuilder stringBuilder = this;
            do
            {
                //… some code
                stringBuilder.m_ChunkChars[index1] = value;
                return;
    	        // …. Some more code
            }
          }
        }
