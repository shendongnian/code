    class TVM: TermVectorMapper
    {
	public override void SetExpectations(string field, int numTerms, bool storeOffsets, bool storePositions)
        {
        }
    
        public override void Map(string term, int frequency, TermVectorOffsetInfo[] offsets, int[] positions)
        {
        }
    }
    TVM tvm = new TVM();
    reader.GetTermFreqVector(docID, field, tvm);
