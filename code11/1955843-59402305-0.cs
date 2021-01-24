c#
        public TimeSpan Duration { get; set; }
        public int Minutes { get; }
        entity.Property(e => e.Minutes)
            .HasComputedColumnSql("DATEDIFF(MINUTE, 0, Duration)");
