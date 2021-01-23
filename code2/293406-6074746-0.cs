    class Container {
      private Dictionary<string, int> m_voteMap = new Dictionary<string, int>();
    
      public void SetVote(string user, int votes) {
        m_voteMap[user] = votes;
      }
      
      public int GetVotes(string user) {
        int votes;
        if (!m_voteMap.TryGetValue(user, out votes)) {
          votes = 0;
        }
        return votes;
      }
    }
