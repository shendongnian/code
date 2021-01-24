    public class CandidateBufferList
    {
        private List<CircularBuffer<Candidate>> _candidateList = new List<CircularBuffer<Candidate>>();   
        private void Add(Candidate candidate)
        {           
            //Find a matching buffer for the candidate based on distance. More on this later
            //here maxDistance is the maximum distance a candidate can move each frame
            var matches = _candidateList.Where(cb => Distance(candidate.Location, cb.Last.Location) < maxDistance);
            int matchCount = matches.Count();
    
            if (matchCount == 0)
            {
                var cb = new CircularBuffer<Candidate>();
                cb.Add(candidate);
                _candidateList.Add(cb);
            }
            else if (matchCount == 1)
            {
                var match = matches.First();
                if (match.Last.FrameNumber == candidate.FrameNumber)
                {
                    // Ambiguous match 1.
                    throw new Exception("A candidate was already added to this buffer this frame.");
                }
                match.Add(candidate);
            }
            else
            {
                // Ambiguous match 2.
                throw new Exception("More than one matching buffer was found for this candidate");
            }
        }
        public void Update(int frameNumber, List<Candidate> candidates)
        {
            candidates.ForEach(c => Add(c));
            //Remove buffers that didn't match this frame.
            _candidateList.RemoveAll(cb => cb.Last.FrameNumber != frameNumber);
        }
        public List<Point> GetEvents()
        {
            return _candidateList
                .Where(cb => ContourHasGrouwn(cb))                
                .Select(cb => cb.First.Location)
                .ToList();
        }
       
        private bool ContourHasGrouwn(CircularBuffer<Candidate> cb)
        {
            //if contour is not older than 4 frames
            if (!cb.IsFull) return false;
            for (int i = 1; i < cb.Size; i++)
            {
                if (cb[i].ContourSize < cb[i - 1].ContourSize) return false;
            }
            return true;
        }
    }
