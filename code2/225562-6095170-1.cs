    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    namespace CloudOne.Models
    {
    	public class SiteDataContext: DbContext
    	{
    		public DbSet<Brand> Brands { get; set; }
    
    		// Twist our database
    		protected override void OnModelCreating(DbModelBuilder modelBuilder)
    		{
    			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    			base.OnModelCreating(modelBuilder);
    		}
    	}
    }
