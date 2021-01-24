    private static IEnumerable<int[]> Generator(int faces, int count, int generations) {
      IEnumerable<(int[], int, int)> agenda = Generator(faces, count)
        .Select(state => (state, 0, 0));
      for (bool hasWork = true; hasWork;) {
        hasWork = false;
        List<(int[], int, int)> next = new List<(int[], int, int)>();
        foreach (var state in agenda) {
          int explosions = state.Item1.Skip(state.Item2).Count(item => item == faces);
          if (explosions <= 0 || state.Item3 >= generations)
            yield return state.Item1;
          else
            foreach (var newState in
              Generator(faces, explosions).Select(adds => state.Item1.Concat(adds)))
                next.Add((newState.ToArray(), state.Item1.Length, state.Item3 + 1));
        }
        agenda = next;
        hasWork = next.Count > 0;
      }
    }
