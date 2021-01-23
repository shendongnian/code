      modelBuilder.Entity<TestResult>()
        .Map(m =>
          {
            m.Properties(t => new { t.Name, t.Text, t.Units /*other props*/ });
            m.ToTable("Result");
          })
        .Map(m =>
          {
            m.Properties(t => new { t.Status, t.Analysis /*other props*/});
            m.ToTable("Test");
          });
