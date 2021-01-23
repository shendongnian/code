    private bool m_beforeStart;
    private IList<IEnumerable<char>> m_lists;
    private Stack<IEnumerator<char>> m_enumerators;
        
    public bool MoveNext() {
        while (CurrentEnumerator != null && !CurrentEnumerator.MoveNext()) {
            RemoveLastChar(m_stringBuilder);
            PopEnumerator();
         }
         if (CurrentEnumerator == null && ! m_beforeStart) {
             return false;
         }
         m_beforeStart = false;
         while (PushEnumerator()) {
              if (!CurrenEnumerator.MoveNext()) {
                  ClearEnumerators();
                  return false;
              }
              m_stringBuilder.Append(
                  m_currentEnumerator.Current
              );
          }
          return true;
    }
    
    public string Current {
        get {
            return m_stringBuilder.ToString();
        }
    }
    private IEnumerator<char> CurrentEnumerator {
        get {
            return m_enumerators.Count != 0 ? m_enumerators.Peek() : null;
        }
    }
    private void PopEnumerator() {
        if (m_enumerators.Count != 0) {
            m_enumerators.Pop();
        }
    }
    private bool PushEnumerator() {
        if (m_enumerators.Count == m_lists.Count) {
            return false;
        }
        m_enumerators.Push(m_lists[m_enumerators.Count].GetEnumerator());
    }
