	internal class UserMapping : AbstractMappingProvider<User>
	{
		public override void DefineModel( DbModelBuilder modelBuilder )
		{
			base.DefineModel( modelBuilder );
			Map.HasRequired( e => e.Account ).WithRequiredDependent( r => r.User ).WillCascadeOnDelete( true );
		}
	}
	
	internal class AccountMapping : AbstractMappingProvider<Account>
	{
		public override void DefineModel( DbModelBuilder modelBuilder )
		{
			base.DefineModel( modelBuilder );
			Map.HasRequired( e => e.User ).WithRequiredPrincipal( r => r.Account ).WillCascadeOnDelete( true );
		}
	}	
