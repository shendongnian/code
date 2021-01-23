    IEnumerable<TaughtSubject> firstGroup = taughtSubjects
      .GroupBy(t => t.SubjectId)
      .OrderBy(g => g.Count())
      .First()  //the taughtsubjects that are members of the smallest subject group.
      .GroupBy(t => t.FormId)
      .OrderBy(g => g.Count())
      .First(); // and of these taughtsubjects, the members of the smallest form group.
      // and the first member of those.
    TaughtSubject firstElement = firstGroup.First();
