modelBuilder.Entity&lt;Post&gt;(entity =>
{
    entity.HasOne&lt;Category&gt;(s => s.Category)
        .WithMany(c => c.Posts)
        <b>.HasForeignKey(s => s.PostId);</b>  // line A: it is not correct!
    entity.HasOne&lt;User&gt;(s => s.User)
        .WithMany(u => u.Posts)
        <b>.HasForeignKey(s => s.PostId);</b> // line B: it is not correct!
    entity.Property(s => s.CreatedAt)
        .HasDefaultValueSql("SYSUTCDATETIME()");
});
