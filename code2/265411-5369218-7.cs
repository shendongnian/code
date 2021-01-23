	internal class TeamMapping : AbstractMappingProvider<Team>
	{
		public override void DefineModel( DbModelBuilder modelBuilder )
		{
			base.DefineModel( modelBuilder );
			Map.HasOptional( e => e.Company ).WithMany().HasForeignKey( e => e.CompanyID );
			Map.HasMany( e => e.Users ).WithRequired( r => r.Team );
		}
	}	
	
	internal class CompanyMapping : AbstractMappingProvider<Company>
	{
		public override void DefineModel( DbModelBuilder modelBuilder )
		{
			base.DefineModel( modelBuilder );
		}
	}
