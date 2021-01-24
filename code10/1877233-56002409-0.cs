    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
    	public void Configure(EntityTypeBuilder<Task> builder)
    	{
    		builder.HasKey(tsk => tsk.Id);
    		//builder.HasMany(...) relationships et al.
    	}
    }
