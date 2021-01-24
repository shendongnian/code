    private static IEnumerable<int[]> Generator(int faces, int count, int extra) {
      IEnumerable<(int[], int)> agenda = Generator(faces, count)
        .Select(state => (state, 0));
      for (bool hasWork = true; hasWork; ) {
        hasWork = false;
        List<(int[], int)> next = new List<(int[], int)>();
        foreach (var state in agenda) {
          int explosions = Math.Min(
            state.Item1.Skip(state.Item2).Count(item => item == faces),
            extra - state.Item1.Length + count);
          if (explosions <= 0)
            yield return state.Item1;
          else 
            foreach (var newState in 
              Generator(faces, explosions).Select(adds => state.Item1.Concat(adds)))
                next.Add((newState.ToArray(), state.Item1.Length));
        }
        agenda = next;
        hasWork = next.Count > 0;
      }
    }
