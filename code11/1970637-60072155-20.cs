    private static IEnumerable<int[]> Generator(int faces, int count) {
      int[] state = Enumerable.Repeat(1, count).ToArray();
      do {
        yield return state.ToArray(); // safety : let's return a copy of state
        for (int i = state.Length - 1; i >= 0; --i)
          if (state[i] == faces)
            state[i] = 1;
          else {
            state[i] += 1;
            break;
          }
      }
      while (!state.All(item => item == 1));
    }
